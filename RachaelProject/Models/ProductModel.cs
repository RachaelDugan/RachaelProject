using System.ComponentModel;

namespace RachaelProject.Models
{
    public class ProductModel
    {
        [DisplayName("ProductId")]
        public int ProductId { get; set; }
        [DisplayName("Name")]
        public string? Name { get; set; }
        [DisplayName("Breed")]
        public string? Breed { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("FavToy")] 
        public string? FavToy { get; set; }
        [DisplayName("About Me")]
        public string? Description { get; set; }
    }
}
