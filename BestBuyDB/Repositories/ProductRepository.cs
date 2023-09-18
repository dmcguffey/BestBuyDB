

using BestBuyDB.Models;
using Dapper;
using System.Data;

namespace BestBuyDB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //add connection needed for connecting to sql database
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        //CREATE
        public void CreateProduct(Product product)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { Name = product.Name, Price = product.Price, CategoryID = product.CategoryID });
        }

        //READ
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }
        public Product GetProductById(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE ProductID = @id", new { id = id });
        }

        //UPDATE
        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        //DELETE
        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM Categories;");
        }
        public Product AssignCategory()
        {
            //make list for what categories are available
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
    }
}
