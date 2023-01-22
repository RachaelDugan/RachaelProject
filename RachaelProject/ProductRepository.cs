using Dapper;
using RachaelProject.Models;
using System.Data;

namespace RachaelProject
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<ProductModel > GetAllProducts()
        {
            return _conn.Query<ProductModel>("SELECT * FROM producttable;");
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }       
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
