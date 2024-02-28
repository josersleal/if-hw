using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfShopApi.Models;
using IfShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController() { }

        [HttpGet]
        public ActionResult<ProductsResponse> GetAll() => ProductDataService.GetAll();
        
    }
}