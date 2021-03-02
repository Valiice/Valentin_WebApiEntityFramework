using Valentin_EntityFramework.Models;
using System.Collections.Generic;

namespace Valentin_EntityFramework.Services
{
    public interface ICategoryService
    {
        Category GetCategory(string categoryName);
        List<Category> GetCategories();
        List<Category> GetCategoriesWithProducts();
        Category AddCategory(Category category);
        void DeleteCategoryById(int categoryId);
        Category UpdateCategoryById(int categoryIdToEdit, Category categoryEditValues);
        //List<Category> GetCategoriesWithPrice();
    }
}