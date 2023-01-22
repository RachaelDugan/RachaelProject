using Microsoft.AspNetCore.Mvc;
using RachaelProject.Models;

namespace RachaelProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductModel> productlist = new List<ProductModel>();

            productlist.Add(new ProductModel { 
                ProductId = 1, Name = "Poppy",  
                Breed = "Poodle",  Age = 4, 
                FavToy = "Stuffed Frog", 
                Description = "Good with children and loves to run. Ready for adoption!" 
            });
            productlist.Add(new ProductModel
            {
                ProductId = 2,
                Name = "Biscuit",
                Breed = "Schnauzer",
                Age = 2,
                FavToy = "Red Ball",
                Description = "Ready for a nice warm lap, good for a quiet home."
            });
            productlist.Add(new ProductModel
            {
                ProductId = 3,
                Name = "Hank",
                Breed = "Blood Hound",
                Age = 6,
                FavToy = "Rope",
                Description = "Ready to be man's best friend. That dog will hunt!"
            });

            return View(productlist);
        }
    }
}







