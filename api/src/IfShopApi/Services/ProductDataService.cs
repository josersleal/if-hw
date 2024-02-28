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
        Thumbnail = new Uri("https://via.placeholder.com/150"),
        Images = new Uri[] {
          new Uri("https://via.placeholder.com/150"),
          new Uri("https://via.placeholder.com/150"),
          new Uri("https://via.placeholder.com/150")
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
        Thumbnail = new Uri("https://via.placeholder.com/150"),
        Images = new Uri[] {
          new Uri("https://via.placeholder.com/150"),
          new Uri("https://via.placeholder.com/150"),
          new Uri("https://via.placeholder.com/150")
        }
      }
    };
  }

  public static ProductsResponse GetAll() => new ProductsResponse{ Products=ProductsList} ;
}
