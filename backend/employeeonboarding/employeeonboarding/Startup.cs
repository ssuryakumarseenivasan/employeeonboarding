using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using EmplyeeData.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emonboardingAppApi.model.Abstract;
using emonboardingAppApi.model.Services;
using emonboardingAppApi.model.Repository;
using Microsoft.EntityFrameworkCore;

namespace employeeonboarding
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
            services.AddDbContext<EmployeeDbContext>(opts =>
            {
                opts.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();

            services.AddSwaggerGen(context =>
            {
                context.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Test API",
                    Version = "s1"
                });
            });

            services.AddCors(opt =>

            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

            });

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                app.UseSwagger(context =>
                {
                    context.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        string hostValue = httpReq.Host.Value;
                        if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
                        {
                            var pathBase = httpReq.Headers["X-Forwarded-Host"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(pathBase))
                            {
                                hostValue = pathBase.Trim();
                            }
                        }
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{hostValue}{httpReq.PathBase.Value}" } };
                    });
                });



            }


            app.UseHttpsRedirection();


            app.UseAuthentication();

            app.UseSwaggerUI(context =>
            {
                context.SwaggerEndpoint("s1/swagger.json", "My SmartTools API V1");
            });


            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
