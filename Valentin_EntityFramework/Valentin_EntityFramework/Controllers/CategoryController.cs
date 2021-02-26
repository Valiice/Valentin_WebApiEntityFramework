using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Services;
using Valentin_EntityFramework.Models;
using Valentin_EntityFramework.Db;

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
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetCategories();
            return categories;
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
        public ActionResult CreateNewCategory(Category newCategory)
        {
            _categoryService.AddCategory(newCategory);
            return Ok();
        }
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
