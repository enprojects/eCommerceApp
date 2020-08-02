using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    using (var scoped = host.Services.CreateScope())
            //    {
            //        //var serv = scope.ServiceProvider.GetRequiredService<StoreContext>();
            //        //serv.Products.Add(new Product { 
            //        // Description=" add manually ",
            //        //  Name ="Eyal best prod", 
            //        //   Price =13.66M,
            //        //    ProductBrand = new ProductBrand { 
            //        //     Name ="PB manually"
            //        //    }, 
            //        //     ProductType = new ProductType { 
                         
            //        //         Name ="electronics"
            //        //     }
            //        //});
            //        //serv.SaveChanges();
            //        //if (serv.Products.Count()== 0)
            //        //{
            //            //var json = System.IO.File.ReadAllText("data.json");
            //            //serv.ProductBrands.Add(new ProductBrand { Name = "The best brand" });
            //            //serv.ProductTypes.Add(new ProductType { Name = "Special type" });

            //            //var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(json);

                    
            //            //serv.Products.AddRange(products);
            //            //serv.SaveChanges();
            //        //}
            //    }

            //} 
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
