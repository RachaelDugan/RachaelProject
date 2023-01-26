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
        public ProductModel GetProductById(int id)
        {
            return _conn.QuerySingle<ProductModel>("SELECT * FROM producttable WHERE ProductID = @id", new { id = id });
        }

        public void Insert(ProductModel pupToInsert)
        {
            _conn.Execute("INSERT INTO producttable (ProductId, Name, Breed, Age, FavToy, Description)" +
                "VALUES (@ProductId, @Name, @Breed, @Age, @FavToy, @Description);",
                new
                {
                    ProductId = pupToInsert.ProductId,
                    Name = pupToInsert.Name,
                    Breed = pupToInsert.Breed,
                    Age = pupToInsert.Age,
                    FavToy = pupToInsert.FavToy,
                    Description = pupToInsert.Description
                });
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            return _conn.Query<ProductModel>("SELECT * FROM producttable;");
        }
        public ContactListModel AssignProduct()
        {
            var newProduct = GetProducts();
            var product = new ProductModel();
            product.NewProduct = newProduct;
            return (ContactListModel)newProduct;
        }

        public void Delete(ProductModel product)
        {
            _conn.Execute("DELETE FROM producttable WHERE ProductId = @ProductId;", new { id = product.ProductId });
        }

        public void Update(ProductModel product)
        {
            _conn.Execute("UPDATE producttable SET ProductId = @ProductId, Name = @name," +
                "WHERE ProductID = @id",
                new 
                { 
                    productid = product.ProductId, 
                    name = product.Name, 
                    breed = product.Breed, 
                    age = product.Age, 
                    favtoy = product.FavToy, 
                    description = product.Description
                });
        }

       
    }
}
