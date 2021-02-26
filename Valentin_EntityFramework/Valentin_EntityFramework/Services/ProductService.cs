using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_EntityFramework.Db;
using Valentin_EntityFramework.Models;

namespace Valentin_EntityFramework.Services
{
    public class ProductService : IProductService
    {
        public void AddProduct(Product product)
        {
            using (var db = new ProductDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void DeleteProductById(int productId)
        {
            using (var db = new ProductDbContext())
            {
                var productToDelete = db.Products.FirstOrDefault(product => product.Id == productId);
                db.Products.Remove(productToDelete);
                db.SaveChanges();
            }
        }

        public Product GetProduct(string productName)
        {
            using (var db = new ProductDbContext())
            {
                var product = db.Products.FirstOrDefault(product => product.Name == productName);
                return product;
            }
        }

        public List<Product> GetProducts()
        {
            using (var db = new ProductDbContext())
            {
                var products = db.Products.Include(x => x.Category).ToList();
                return products;
                //return db.Products.ToList();
            }
        }


        public Product UpdateProductById(int productIdToEdit, Product productEditValues)
        {
            using (var db = new ProductDbContext())
            {
                var productToEdit = db.Products.First(Product => Product.Id == productIdToEdit);
                productToEdit.Name = productEditValues.Name;
                productToEdit.Price = productEditValues.Price;
                db.Products.Update(productToEdit);
                db.SaveChanges();
                return productToEdit;
            }
        }
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
