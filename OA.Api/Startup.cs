using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OA.Repo;
using OA.Service;

namespace OA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //initialize mongo client and database
            DatabaseContext.DbClient = new MongoDB.Driver.MongoClient(Configuration.GetConnectionString("mongodb"));
            DatabaseContext.DbName = Configuration.GetConnectionString("dbName");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //adding cors policy to allow reqs from notes client app
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OA.Api", Version = "v1" });
            });

            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OA.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("AllowMyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/api", async context =>
                {
                    await context.Response.WriteAsync("UserInfo API endpoint root.");
                });
            });
        }
    }
}
