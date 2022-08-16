using Business.Abstract;
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
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IProductService _productService;

        public CategoryController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("categorycaunt")]
        public IActionResult CategoryCount(int categoryId)
        {
            return Ok(_categoryService.CategoryCount());

        }

        [HttpGet("getcategorycountofproduct")]
        public IActionResult GetCategoryCountOfProduct(int categoryId)
        {
            return Ok(_productService.ProductCountOfCategoryId(categoryId));
        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            return Ok(_categoryService.Add(category));
        }
    }
}
