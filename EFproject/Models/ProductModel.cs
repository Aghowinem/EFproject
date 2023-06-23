namespace EFproject.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
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
