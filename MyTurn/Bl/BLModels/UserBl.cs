using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class UserBl
    {
        public static Dto.UserDto LogIn(string phoneNumber, string mail)
        {
            var u1 = Bl.Dal.UserDal.logIn(phoneNumber, mail);
            return Bl.Converters.UserConveter.ToDtoUser(u1);

        }

    }
}
