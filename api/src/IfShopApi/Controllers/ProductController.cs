using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfShopApi.Interfaces;
using IfShopApi.Models;
using IfShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataService ProductDataService;
        public ProductsController(IProductDataService productDS)
        {
            ProductDataService = productDS;
        }

        [HttpGet]
        public async Task< ActionResult<ProductList>> GetAll()
        {
            ProductList products = await ProductDataService.GetProductsAsync();
            return Ok(products);

        }
    }
}