using IfShopApi.Models;

namespace IfShopApi.Interfaces;

public interface IProductDataService
{
  Task<ProductList> GetProductsAsync();

}