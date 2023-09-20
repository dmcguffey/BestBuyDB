

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
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS WHERE CategoryID = @id", new { id = id });
        }

        //UPDATE
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE Products SET Name = @Name, Price = @Price, OnSale = @OnSale, StockLevel = @StockLevel WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, OnSale = product.OnSale, StockLevel = product.StockLevel, id = product.ProductID });
        }

        //DELETE
        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id", new {id =  product.ProductID});
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id", new { id = product.ProductID });
        }

        //For obtaining a list of categories from categories table
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
