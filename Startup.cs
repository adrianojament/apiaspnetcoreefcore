using System;
using ApiAspnetCoreEfCore.Data;
using ApiAspnetCoreEfCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace apiaspnetcoreefcore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);      

            //So ira criar uma vez na memoria, a maioria das vezes é para usar datacontext
            services.AddScoped<StoreDataContext,StoreDataContext>();
            //Irá criar todas vezes.
            services.AddTransient<ProductRepository, ProductRepository>();
        }

        private void StoreDataContext()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
            
            app.UseMvc();
        }
    }
}
