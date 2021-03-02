using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Services;
using Valentin_EntityFramework.Models;
using Valentin_EntityFramework.Db;
using Valentin_EntityFramework.DTO;

namespace Valentin_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("many categories")]
        public ActionResult<List<ResponseCategoryDTO>> GetAllCategories()
        {
            var categories = _categoryService.GetCategories();
            var listOfResponseCategoryDTO = new List<ResponseCategoryDTO>();
            foreach(var categ in categories)
            {
                var responseCategoryDTO = new ResponseCategoryDTO();
                responseCategoryDTO.Id = categ.Id;
                responseCategoryDTO.Name = categ.Name;
                listOfResponseCategoryDTO.Add(responseCategoryDTO);
            }
            return listOfResponseCategoryDTO;
        }
        [HttpGet("many with products")]
        public ActionResult<List<ResponseCategoryWithProductsDTO>> GetAllCategoriesWithProducts()
        {
            var categories = _categoryService.GetCategoriesWithProducts();
            var listOfResponseCategoryDTO = new List<ResponseCategoryWithProductsDTO>();
            foreach (Category categ in categories)
            {
                var responseCategoryDTO = new ResponseCategoryWithProductsDTO();
                responseCategoryDTO.Id = categ.Id;
                responseCategoryDTO.Name = categ.Name;
                responseCategoryDTO.Products = new List<ResponseProductDTO>();
                foreach (Product product in categ.Products)
                {
                    var responseProductDTO = new ResponseProductDTO();
                    responseProductDTO.Id = product.Id;
                    responseProductDTO.Name = product.Name;
                    responseProductDTO.Price = product.Price;
                    responseCategoryDTO.Products.Add(responseProductDTO);
                }
                listOfResponseCategoryDTO.Add(responseCategoryDTO);
            }
            return Ok(listOfResponseCategoryDTO);
        }
        [HttpGet("many with price")]
        public ActionResult<List<ResponseCategoryWithPriceDTO>> GetAllCategoriesWithPrice()
        {
            var categories = _categoryService.GetCategoriesWithProducts();
            var listOfResponseCategoryDTO = new List<ResponseCategoryWithPriceDTO>();
            foreach (Category categ in categories)
            {
                var responseCategoryDTO = new ResponseCategoryWithPriceDTO();
                responseCategoryDTO.Id = categ.Id;
                responseCategoryDTO.Name = categ.Name;
                responseCategoryDTO.TotalPrice = 0;
                foreach (Product product in categ.Products)
                {
                    responseCategoryDTO.TotalPrice += product.Price;
                }
                listOfResponseCategoryDTO.Add(responseCategoryDTO);
            }
            return Ok(listOfResponseCategoryDTO);
        }
        [HttpGet("one categories")]
        public ActionResult<Category> GetCategory(string categoryName)
        {
            var category = _categoryService.GetCategory(categoryName);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public ActionResult<Category> CreateNewCategory(CreateCategoryDTO createCategoryDTO)
        {
            var newCategory = new Category();
            newCategory.Name = createCategoryDTO.Name;
            var categoryFromDB = _categoryService.AddCategory(newCategory);
            return Ok(categoryFromDB);
        }
        //public ActionResult CreateNewCategory(Category newCategory)
        //{
        //    _categoryService.AddCategory(newCategory);
        //    return Ok();
        //}
        [HttpDelete]
        public ActionResult DeleteCategoryById(int categoryId)
        {
            _categoryService.DeleteCategoryById(categoryId);
            return Ok();
        }
        [HttpPut]
        public ActionResult<Category> UpdateCategoryById(int categoryIdToEdit, Category categoryEditValues)
        {
            var editedCategory = _categoryService.UpdateCategoryById(categoryIdToEdit, categoryEditValues);
            return Ok(editedCategory);
        }
    }
}
