

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
            throw new NotImplementedException();
        }

        //READ
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
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
    }
}
