using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Api.Authorization;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configuração para inicializar as classes do repositorio..
            var connectionString = Configuration.GetConnectionString("ProjetoAPI02");
            services.AddTransient(map => new UsuarioRepository(connectionString));

            //configuração do swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API para Autenticação de Usuários",
                        Version = "v1",
                        Description = "Projeto desenvolvido em NET CORE 3.1 API com Dapper",
                        Contact = new OpenApiContact
                        {
                            Name = "COTI Informática - Curso de C# WebDeveloper",
                            Url = new Uri("http://wwww.cotiinformatica.com.br"),
                            Email = "contato@cotiinformatica.com.br"
                        }
                    });
            });

            //Configuração do JWT
            var settingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(settingsSection);

            var jwtSettings = settingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new JwtConfiguration(jwtSettings));

            //CORS
            services.AddCors(
               s => s.AddPolicy("DefaultPolicy",
               builder =>
               {
                   builder.AllowAnyOrigin()  //permite que qualquer servidor acesse a API
                          .AllowAnyMethod()  //permite que qualquer método da API seja acessado (POST, GET, etc)
                          .AllowAnyHeader(); //permite que sejam enviados parametros de cabeçalho para API
               }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
