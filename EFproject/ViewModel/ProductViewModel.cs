using EFproject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFproject.ViewModel
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        [NotMapped]
        public IFormFile ProductImage { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public int Price { get; set; }

        //One to One
        public ProductDetailsModel Details { get; set; }
    }
}
