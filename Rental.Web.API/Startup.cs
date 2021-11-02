using MediatR;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Rental.Web.API.Application.Queries.client.GetAllClients;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.DTOs;
using Rental.Web.API.Infrastructure.Data;
using Rental.Web.API.Infrastructure.Models;
using Rental.Web.API.Infrastructure.Repository;
using System;

namespace Rental.Web.API
{
    public class Startup
    {
        readonly string corsConfig = "corsConfig";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configuration Cors/security policy
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfig,
                                    builder =>
                                    {
                                        builder.WithHeaders("*");//post
                                        builder.WithOrigins("*");//getAll
                                        builder.WithMethods("*");//Put/delete
                                    });
            });

            //OData
            services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);
            services.AddOData();

            //MediatR
            services.AddMediatR(typeof(GetAllClientsHandler).Assembly);
            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Repository/Dependency Inyection
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            //DB sqserver
            services.AddDbContext<LESAContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-9LJ95CE; Database=LESA; Trusted_Connection=True; User=sa; Password=root;"
                    ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Cors
            app.UseCors(corsConfig);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Odata
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Filter().Expand().OrderBy().Count().MaxTop(100);
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
            
        }

        private IEdmModel GetEdmModel()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<Client>("Client");

            return edmBuilder.GetEdmModel();
        }
    }
}
