using System.ComponentModel.DataAnnotations;
namespace ProjectTWO.ServiceLayer.Model
{
    public class Categoryes
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
