using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
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
                return BadRequest("Veri boş");
            }

        }
        [HttpGet("GetAllByCategoryId")]
        public IActionResult GetAllByCategoryId(int categoryid)
        {
            var result = _productService.GetAllByCategoryId(categoryid);
            return Ok(result);
        }

        [HttpGet("GetAllUnitPrice")]
        public IActionResult GetAllUnitPrice(decimal min, decimal max)
        {
            var result = _productService.GetAllUnitPrice(min, max);
            return Ok(result);
        }

        [HttpGet("getproductcountofcategoryId")]
        public IActionResult GetProductCountOfCategoryId(int categoryId)
        {
            var result = _productService.ProductCountOfCategoryId(categoryId);
            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            Random r = new Random();
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");
            if (!Directory.Exists(uploadPath)) { Directory.CreateDirectory(uploadPath); }
                
            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");
                using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }
    }
}
