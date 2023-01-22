using RachaelProject.Models;

namespace RachaelProject
{
    public interface IProductRepository
    {
        public IEnumerable<ProductModel> GetAllProducts();
        //public ProductModel GetProduct(int id);
       
        ProductModel GetProductById(int id);
        public void Insert(ProductModel pupToInsert);

        public void Delete(ProductModel product);
        public void Update(ProductModel product);
        
    }
}
