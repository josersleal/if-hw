using IfShopApi.Models;

namespace IfShopApi.Services;

public static class ProductDataService
{
  static List<Product> ProductsList { get; }



  static ProductDataService()
  {
    ProductsList = new List<Product>() {
      new Product() {
        Id = 1,
        Title = "Product 1",
        Description = "Product 1 description",
        Price = 100,
        DiscountPercentage = 0.1,
        Rating = 4.5,
        Stock = 10,
        Brand = "Brand 1",
        Category = "Category 1",
        Thumbnail = new Uri("https://cdn.dummyjson.com/product-images/1/thumbnail.jpg"),
        Images = new Uri[] {
          new Uri("https://cdn.dummyjson.com/product-images/1/1.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/1/2.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/1/3.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/1/4.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/1/thumbnail.jpg")
        }
        
      },
      new Product() {
        Id = 2,
        Title = "Product 2",
        Description = "Product 2 description",
        Price = 200,
        DiscountPercentage = 0.2,
        Rating = 4.5,
        Stock = 10,
        Brand = "Brand 2",
        Category = "Category 2",
        Thumbnail = new Uri("https://cdn.dummyjson.com/product-images/1/thumbnail.jpg"),
        Images = new Uri[] {
          new Uri("https://cdn.dummyjson.com/product-images/2/1.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/2/2.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/2/3.jpg"),
          new Uri("https://cdn.dummyjson.com/product-images/2/thumbnail.jpg")
        }
      }
    };
  }

  public static ProductsResponse GetAll() => new ProductsResponse{ Products=ProductsList} ;
}

