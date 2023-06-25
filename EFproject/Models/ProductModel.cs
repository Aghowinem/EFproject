using EFproject.Validation;
using System.ComponentModel.DataAnnotations;

namespace EFproject.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter valid name!")]
        [Name(ErrorMessage = "This name is not allowed!!!")]
        //[StringLength(10)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public int Price { get; set; }

        //One to One
        public ProductDetailsModel Details { get; set; }

        //Many to Many
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
