using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
  public  class BusinessBl
    {   
        public static  Dto.BusinessDto LogIn(string password,string mail)
        {
            var b1 = Bl.Dal.BusinessDal.logIn(password, mail);
            return Bl.Converters.BusinessConverter.ToDtoBusiness(b1);

        }

        public static int AddBusiness(Dto.BusinessDto business)
        {
            try
            {
                return Dal.BusinessDal.CreateBusiness(business);
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }
        public static Dto.BusinessDto GetBusiness(int idUser)
        {
            return Bl.Converters.BusinessConverter.ToDtoBusiness
                (Dal.BusinessDal.GetBusiness(idUser));
        }
    }
}
