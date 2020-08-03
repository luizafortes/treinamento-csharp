using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto.Repository.Repositories;

namespace Projeto.Presentation.Mvc
{
    public class Startup
    {
        //construtor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //interface utilizada para ler o arquivo appsettings.json
        public IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //habilitar o uso do MVC
            //services.AddMvc(); //NET CORE 2.1
            services.AddControllersWithViews(); //NET CORE 3.1

            //mapear as classes ClienteRepository e DependenteRepository
            //de forma que possamos passar o caminho da connectionString
            //para estas classes
            var connectionString = Configuration.GetConnectionString("ProjetoMVC01");

            services.AddTransient(map => new ClienteRepository(connectionString));
            services.AddTransient(map => new DependenteRepository(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //NET CORE 3.1 ou 2.1
            app.UseRouting(); //NET CORE 3.1

            //NET CORE 3.1
            app.UseEndpoints(endpoints =>
            {
                //mapear a página inicial do projeto
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}"
                );
            });
        }
    }
}
