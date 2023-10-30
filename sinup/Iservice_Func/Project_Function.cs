using sinup.ServiceLayer.Data;
using System.Collections.Generic;

namespace ProjectTWO.Iservice_Func
{
    public class Project_Function
    {
        ProjectDB dB = new ProjectDB();
        public Project_Function()
        {

        }

        public void Add_Registr(List<string> registrations)
        {
            dB.serviceModels.AddRange((IEnumerable<sinup.ServiceLayer.User.ServiceModel>)registrations);
            dB.SaveChanges();
        }
    }
}
