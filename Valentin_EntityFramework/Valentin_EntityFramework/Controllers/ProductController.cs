using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Models;
using Valentin_EntityFramework.Db;
using Valentin_EntityFramework.Services;

namespace Valentin_EntityFramework.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("many products")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("one product")]
        public ActionResult<Product> GetProduct(string productName)
        {
            var product = _productService.GetProduct(productName);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult CreateNewProduct(Product newProduct)
        {
            _productService.AddProduct(newProduct);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteHouseById(int productId)
        {
            _productService.DeleteProductById(productId);
            return Ok();
        }
        [HttpPut]
        public ActionResult<Product> UpdateProductById(int productIdToEdit, Product productEditValues)
        {
            var editedProduct = _productService.UpdateProductById(productIdToEdit, productEditValues);
            return Ok(editedProduct);
        }
    }
}
