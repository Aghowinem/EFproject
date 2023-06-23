namespace EFproject.Models
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string MoreDescription { get; set; }
        public string Image { get; set; }

        //OneToOne
        public int ProductModelId { get; set; }
    }
}
