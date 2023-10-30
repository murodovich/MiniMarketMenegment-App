using System.ComponentModel.DataAnnotations;

namespace ProjectTWO.ServiceLayer.Model
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string ProdCat { get; set; }







    }
}
