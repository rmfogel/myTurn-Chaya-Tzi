using Bl;
using Bl.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Converters
{
   public class UserConveter
    {
        public static Dal.User ToDalUser(Dto.UserDto userDto)
        {
            Dal.User user = new User();
            user.id = userDto.id;
            user.firstName = userDto.firstName;
            user.lastName = userDto.lastName;
            user.phoneNumber = userDto.phoneNumber;
            user.email = userDto.email;
           

            return user;

        }
        public static List<User> ToDalUserList(List<Dto.UserDto> userListDto)
        {
            List<User> userListDal = new List<User>();

            foreach (var item in userListDto)
            {
                userListDal.Add(ToDalUser(item));
            }
            return userListDal;

        }

        public static Dto.UserDto ToDtoUser(User user)
        {
            Dto.UserDto userDto = new Dto.UserDto();
            userDto.id = user.id;
            userDto.firstName = user.firstName;
            userDto.lastName = user.lastName;
            userDto.phoneNumber = user.phoneNumber;
            userDto.email = user.email;

            return userDto;

        }
        public static List<Dto.UserDto> ToDtoUserList(List<User> users)
        {
            List<Dto.UserDto> usersDto = new List<Dto.UserDto>();

            foreach (var item in users)
            {
                usersDto.Add(ToDtoUser(item));
            }
            return usersDto;

        }
    }
}
