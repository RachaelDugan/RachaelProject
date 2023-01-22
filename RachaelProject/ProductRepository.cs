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
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _conn.Query<ProductModel>("SELECT * FROM producttable;");
        }
        //public ProductModel GetProduct(int id)
        //{
        //    return _conn.QuerySingle<ProductModel>("SELECT * FROM producttable WHERE ProductId = @id", new { id = id });
        //}

        public ProductModel GetProductById(int id)
        {
            return _conn.QuerySingle<ProductModel>("SELECT * FROM producttable WHERE ProductID = @id", new { id = id });
        }

        public void Insert(ProductModel pupToInsert)
        {
            _conn.Execute("INSERT INTO producttable (ProductId, Name, Breed, Age, FavToy, Description) " +
                "VALUES (@ProductId, @name, @breed, @age, @favtoy, @description);", 
                new 
                { productid = pupToInsert.ProductId, name = pupToInsert.Name, 
                    breed = pupToInsert.Breed, age = pupToInsert.Age, 
                     favtoy = pupToInsert.FavToy, 
                    description = pupToInsert.Description });
        }

        public void Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductModel product)
        {
            _conn.Execute("UPDATE producttable " +
                "SET ProductId = @ProductId, Name = @name, Breed = @breed, Age = @age, Favtoy = @favtoy, Description = @description " +
                "WHERE ProductID = @id",
                new { productid = product.ProductId, name = product.Name, breed = product.Breed, 
                    age = product.Age, favtoy = product.FavToy, 
                    description = product.Description});
        }

       
    }
}
