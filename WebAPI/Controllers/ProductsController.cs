using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return Ok(result);
        }
        [HttpGet("GetByProductName")]
        public IActionResult GetByProductName(string productName)
        {
            var result = _productService.GetByName(productName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet("GetAllByCategoryId")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetAllByCategoryId(id);
            return Ok(result);
        }

        [HttpGet("GetAllUnitPrice")]
        public IActionResult GetAllUnitPrice(decimal min, decimal max)
        {
            var result = _productService.GetAllUnitPrice(min, max);
            return Ok(result);
        }
    }
}
