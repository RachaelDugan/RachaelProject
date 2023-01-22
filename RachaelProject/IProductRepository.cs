using RachaelProject.Models;

namespace RachaelProject
{
    public interface IProductRepository
    {
        public IEnumerable<ProductModel> GetAllProducts();
       
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);

        int Delete(ProductModel product);
        int Update(ProductModel product);
    }
}
