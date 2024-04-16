using Route.Menu.Core.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Route.Menu.Infrastructure.Data
{
    public static class ApplicationContextSeed
    {

        public async static Task SeedAsync(ApplicationDbContext _dbContext)
        {
            if (_dbContext.ProductBrands.Count() == 0)
            {
                var brandsData = File.ReadAllText("../Route.Menu.Infrastructure/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }


            if (_dbContext.ProductCategories.Count() == 0)
            {
                var categoryData = File.ReadAllText("../Route.Menu.Infrastructure/Data/DataSeed/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData);

                if (Categories?.Count > 0)
                {
                    foreach (var Category in Categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(Category);
                        await _dbContext.SaveChangesAsync();

                    }
                }

            }


            if (_dbContext.Products.Count() == 0)
            {
                var ProductData = File.ReadAllText("../Route.Menu.Infrastructure/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                if (products?.Count > 0)
                {
                    foreach (var Product in products)
                    {
                        _dbContext.Set<Product>().Add(Product);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }

    }
}
