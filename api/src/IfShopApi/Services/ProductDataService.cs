using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfShopApi.Interfaces;
using IfShopApi.Models;

namespace IfShopApi.Services;

public class ProductDataService : IProductDataService
{
  private readonly IHttpClientFactory clientFactory;


  public ProductDataService(IHttpClientFactory clientFactoryIn)
  {
    clientFactory = clientFactoryIn ?? throw new ArgumentNullException();
  }

  // TODO: change usage to dto
  public async Task<ProductList> GetProductsAsync()
  {
    var client = clientFactory.CreateClient("DummyJsonApi");

    try
    {
      var response = await client.GetAsync("/products");
      response.EnsureSuccessStatusCode();

      // TODO: check for null?
      return await response.Content.ReadFromJsonAsync<ProductList>();
      ;
    }
    catch (HttpRequestException ex)
    {
      throw new Exception("Error getting products API", ex);
    }
  }
}
