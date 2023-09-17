using System;
using System.Collections.Generic;
using BestBuyDB.Models;

namespace BestBuyDB.Repositories
{
    public interface IProductRepository
    {
        //CREATE
        public void CreateProduct(Product product);
        //READ
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        //UPDATE
        public void UpdateProduct(Product product);
        //DELETE
        public void DeleteProduct(Product product);
    }
}
