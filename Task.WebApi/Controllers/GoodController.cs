using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Dapper;
using System.Data.SqlClient;
using Task.Business.Services.Abstractions;
namespace Task.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly IGoodtService _productService;

        public GoodController(IGoodtService productService)
        {
            _productService = productService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetGoodsTree(string code)
        {

            var result=await _productService.GetGoodsByCode(code);
           
            return Ok(result);
        }

    }
   
}

