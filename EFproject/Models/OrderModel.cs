namespace EFproject.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //ManyToMany
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

    }
}
