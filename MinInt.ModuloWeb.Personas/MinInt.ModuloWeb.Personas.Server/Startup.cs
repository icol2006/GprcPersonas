using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinInt.ModuloWeb.Personas.Api;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Reflection;
using MediatR;
using MinInt.ModuloWeb.Personas.Server.Services;
using AutoMapper;

namespace MinInt.ModuloWeb.Personas.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
               opts => opts.UseSqlServer(
                       Configuration.GetConnectionString("DataBaseConnection"),
                       x => x.MigrationsHistoryTable("__EFMigrationsHistory")
               )
            );

            services.AddMediatR(Assembly.Load("MinInt.ModuloWeb.Personas.EventHandlers"));
            services.AddMediatR(Assembly.Load("MinInt.ModuloWeb.Personas.Queries"));

            services.AddAutoMapper(Assembly.Load("MinInt.ModuloWeb.Personas.Queries"));

            CrossCutting.IoCRegister.AddRegistration(services);

            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<PersonaService>();
                endpoints.MapGrpcService<JefaturaService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
