using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Db;
using Valentin_EntityFramework.Models;

namespace Valentin_EntityFramework.Services
{
    public class CategoryService : ICategoryService
    {
        public Category AddCategory(Category category)
        {
            using (var db = new ProductDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return category;
            }
        }

        public void DeleteCategoryById(int categoryId)
        {
            using (var db = new ProductDbContext())
            {
                var categoryToDelete = db.Categories.FirstOrDefault(category => category.Id == categoryId);
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
            }
        }
        public Category GetCategory(string categoryName)
        {
            using (var db = new ProductDbContext())
            {
                var category = db.Categories.FirstOrDefault(category => category.Name == categoryName);
                return category;
            }
        }

        public List<Category> GetCategories()
        {
            using (var db = new ProductDbContext())
            {
                return db.Categories.ToList();
            }
        }


        public Category UpdateCategoryById(int categoryIdToEdit, Category categoryEditValues)
        {
            using (var db = new ProductDbContext())
            {
                var categoryToEdit = db.Categories.First(Category => Category.Id == categoryIdToEdit);
                categoryToEdit.Name = categoryEditValues.Name;
                categoryToEdit.Products = categoryEditValues.Products;
                db.Categories.Update(categoryToEdit);
                db.SaveChanges();
                return categoryToEdit;
            }
        }

        public List<Category> GetCategoriesWithProducts()
        {
            using (var db = new ProductDbContext())
            {
                var listOfCategories = db.Categories.Include(x => x.Products).ToList();
                return listOfCategories;
            }
        }

        //public List<Category> GetCategoriesWithPrice()
        //{
        //    using (var db = new ProductDbContext())
        //    {
        //        var listOfCategories = db.Categories.Include(x => x.Products).ToList();
        //        return listOfCategories;
        //    }
        //}
    }
}
