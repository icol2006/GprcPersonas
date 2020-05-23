using MinInt.ModuloWeb.Personas.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using MinInt.ModuloWeb.Personas.Api.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediatR;
using Emails;
using System;
using System.Net.Http;
using AutoMapper;

namespace MinInt.ModuloWeb.Personas.Api
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddDbContext<ApplicationDbContext>(
              opts => opts.UseSqlServer(
                      Configuration.GetConnectionString("DataBaseConnection"),
                      x => x.MigrationsHistoryTable("__EFMigrationsHistory")
              )
           );

            SwaggerConfig.AddRegistration(services);

            services.AddMediatR(Assembly.Load("MinInt.ModuloWeb.Personas.EventHandlers"));
            services.AddMediatR(Assembly.Load("MinInt.ModuloWeb.Personas.Queries"));

            services.AddAutoMapper(Assembly.Load("MinInt.ModuloWeb.Personas.Queries"));

            //var httpClientHandler = new HttpClientHandler
            //{
            //    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            //};

            //services.AddGrpcClient<Mailer.MailerClient>(c => c.Address = new Uri(Configuration["EmailsServiceEndpoint"]))
            //    .ConfigureChannel(opt => opt.HttpClient = new HttpClient(httpClientHandler));

            services.Configure<UrlsConfig>(Configuration);

            services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SwaggerConfig.AddRegistration(app);

            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
