using System;
using GhostProject.App.DataAccess;
using GhostProject.App.Web.Filters;
using GhostProject.App.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;

namespace GhostProject.App.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AppDatabase"), opt =>
                    opt.MigrationsAssembly("GhostProject.App.DbMigrations"));
            });


            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services
                .RegisterServices(_configuration)
                .RegisterValidators()
                .RegisterAppSettings(_configuration);

            services.AddScoped<ValidationFilter>();

            services.AddRouting(r => r.LowercaseUrls = true);

            services
                .AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddNewtonsoftJson(opt =>
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyOrigin();
                    });
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddOpenApiDocument(configure => { configure.Title = "Ghost Recruiter API"; });

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            try
            {
                using (var serviceScope =
                       app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                    context?.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
            app.UseOpenApi();

            // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger documents by default on `/swagger`            }
            app.UseSwaggerUi3();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .SetIsOriginAllowed(_=>true)
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseBusinessExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseEndpoints(endpoints => { endpoints.MapHealthChecks("/health"); });
        }
    }
}
