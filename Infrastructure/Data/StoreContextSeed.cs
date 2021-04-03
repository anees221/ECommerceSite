using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entitities;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task AsyncSeed(StoreContext context,ILoggerFactory loggerFactory)
        {

            try
            
            {

           //1
            //Now we are retreving data for ProdcuctsBrand Table
                if (!context.ProductBrands.Any())
                {
                    var BrandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                   var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                    var brands = productBrands;

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);

                    }
                    await context.SaveChangesAsync();
                }

        //2
        //Now we are retreving data for Types Table

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);

                    }
                    await context.SaveChangesAsync();

                }

                //3
             //Now we are retreving data for Products Table

                if (!context.Products.Any())
                {
                
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Products>>(productsData);

                foreach (var item in products)
                {
                    context.Products.Add(item);

                }
                await context.SaveChangesAsync();
                
               }

                
}

    catch(Exception ex)
        {
           var logger=loggerFactory.CreateLogger<StoreContext>();
           logger.LogError(ex.Message);
       }


        }

    }
}

