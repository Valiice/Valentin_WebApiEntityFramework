using Valentin_EntityFramework.Models;
using System.Collections.Generic;

namespace Valentin_EntityFramework.Services
{
    public interface IProductService
    {
        Product GetProduct(string productName);
        List<Product> GetProducts();
        void AddProduct(Product product);
        void DeleteProductById(int productId);
        Product UpdateProductById(int productIdToEdit, Product productEditValues);
        int GetTotalPrice();
    }
}