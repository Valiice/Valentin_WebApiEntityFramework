using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Models;
using Valentin_EntityFramework.Db;
using Valentin_EntityFramework.Services;
using Valentin_EntityFramework.DTO;

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
        public ActionResult<List<ResponseProductWithCategoryDTO>> GetAllProducts()
        {
            var products = _productService.GetProducts();
            var listOfResponseProductDTO = new List<ResponseProductWithCategoryDTO>();
            foreach (var pro in products)
            {
                var responseProductDTO = new ResponseProductWithCategoryDTO();
                responseProductDTO.Id = pro.Id;
                responseProductDTO.Name = pro.Name;
                responseProductDTO.HiddenCode = pro.HiddenCode;
                responseProductDTO.Price = pro.Price;
                responseProductDTO.CategoryId = pro.CategoryId;
                responseProductDTO.CategoryName = pro.Category.Name.ToString();
                listOfResponseProductDTO.Add(responseProductDTO);
            }
            return Ok(listOfResponseProductDTO);
        }
        //public ActionResult<List<Product>> GetAllProducts()
        //{
        //    var products = _productService.GetProducts();
        //    return Ok(products);
        //}
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
        [HttpGet("total price")]
        public ActionResult GetTotalPrice()
        {
            var totalPrice = _productService.GetTotalPrice();
            return Ok(totalPrice);
        }
        [HttpPost]
        public ActionResult CreateNewProduct(CreateProductDTO createProductDTO)
        {
            //var products = _productService.GetProducts();
            var productToInsertInDB = new Product();
            productToInsertInDB.Name = createProductDTO.Name;
            productToInsertInDB.Price = createProductDTO.Price;
            productToInsertInDB.HiddenCode = createProductDTO.HiddenCode;
            productToInsertInDB.CategoryId = createProductDTO.CategoryId;
            _productService.AddProduct(productToInsertInDB);
            return Ok();
        }
        //public ActionResult CreateNewProduct(Product newProduct)
        //{
        //    _productService.AddProduct(newProduct);
        //    return Ok();
        //}
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
