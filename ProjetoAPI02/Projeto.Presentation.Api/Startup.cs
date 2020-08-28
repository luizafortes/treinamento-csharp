using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Infra.Data.Repositories;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

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

