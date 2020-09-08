using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helper;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace API
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
             
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddDbContext<StoreContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddControllers();

            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
          
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>

                  policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithOrigins("http://localhost:4200")));

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(Configuration
                    .GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         

            app.UseHttpsRedirection();

            //  app.UseStaticFiles(); // for wwwroot folder (not tested)
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Content")
                ),
                RequestPath = "/content"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
