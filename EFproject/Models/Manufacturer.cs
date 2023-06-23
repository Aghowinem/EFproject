namespace EFproject.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //OneToMany
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();


    }
}
