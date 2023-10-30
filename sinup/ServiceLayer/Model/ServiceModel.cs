using System.ComponentModel.DataAnnotations;

namespace sinup.ServiceLayer.User
{
    public class ServiceModel
    {

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }




    }
}
