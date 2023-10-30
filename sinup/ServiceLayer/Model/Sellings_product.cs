using System.ComponentModel.DataAnnotations;

namespace ProjectTWO.ServiceLayer.Model
{
    public class Sellings_product
    {
        [Key]
        public int prodID { get; set; }

        public string ProdName { get; set; }

        public int ProdPrice { get; set; }

        public int ProdQty { get; set; }

        public int Total { get; set; }
    }
}
