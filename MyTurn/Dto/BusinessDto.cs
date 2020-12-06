using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class BusinessDto
    {
       //todo: change all references acording to the changes in  proparties here after asking Rachel;
      

        public int id { get; set; }
        public Nullable<int> idCategory { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }


    
    }
}
