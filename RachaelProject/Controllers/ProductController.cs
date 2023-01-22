using Microsoft.AspNetCore.Mvc;
using RachaelProject.Models;

namespace RachaelProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
        public IActionResult UpdateProduct(int id)
        {
            ProductModel prod = repo.GetProductById(id);
            if (prod == null)
            {
                return View("PupNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(ProductModel product)
        {
            repo.Update(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductId });
        }
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProductById(id);
            return View(product);
        }
    }
}








