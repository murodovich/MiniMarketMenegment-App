using System.ComponentModel.DataAnnotations;

namespace ProjectTWO.ServiceLayer.Model
{
    public class Sellers
    {
        [Key]
        public int SellerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

    }
}
