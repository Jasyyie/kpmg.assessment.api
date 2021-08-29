using System.Reflection;
using Kpmg.Assessment.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Kpmg.Assessment.Api.Handlers;

namespace kpmg.assessment.api
{
    public class Startup
    {
        readonly string AllowAllOrigins = "_allowAllOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(name: AllowAllOrigins, builder =>
            {
                builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "kpmg.assessment.api",
                    Description = "Dog Breed Search ASP.NET Core Web API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Jasmine Kaur",
                        Email = "Jaskhundal@gmail.com",
                        //Url = new Uri("https://www.zedotech.com"),
                    }
                });
            });
            services.AddTransient<IDogService, DogService>();
            services.AddHttpClient();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(DogSearchHandler).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "kpmg.assessment.api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(AllowAllOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
