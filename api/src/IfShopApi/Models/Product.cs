
namespace IfShopApi.Models
{
  using System;
  using System.Collections.Generic;

  public partial class Product
  {
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public long Price { get; set; }

    public double DiscountPercentage { get; set; }

    public double Rating { get; set; }

    public long Stock { get; set; }

    public string Brand { get; set; }

    public string Category { get; set; }

    public Uri Thumbnail { get; set; }

    public Uri[] Images { get; set; }
  }
  public class ProductList
  {
    public Product[] Products { get; set; }

        public static implicit operator ProductList(List<Product> v)
        {
            throw new NotImplementedException();
        }
    }

}

