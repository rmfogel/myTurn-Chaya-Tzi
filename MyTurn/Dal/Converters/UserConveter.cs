using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    class UserConveter
    {
        public static Dal.User ToDalUser(Dto.UserDto userDto)
        {
            Dal.User user = new User();
            user.id = userDto.id;
            user.name = userDto.name;
            user.phoneNumber = userDto.phoneNumber;
            user.email = userDto.email;
           

            return user;

        }
        public static List<Dal.User> ToDalUserList(List<Dto.UserDto> userListDto)
        {
            List<Dal.User> userListDal = new List<User>();

            foreach (var item in userListDto)
            {
                userListDal.Add(ToDalUser(item));
            }
            return userListDal;

        }

        public static Dto.UserDto ToDtoUser(Dal.User user)
        {
            Dto.UserDto userDto = new Dto.UserDto();
            userDto.id = user.id;
            userDto.name = user.name;
            userDto.phoneNumber = user.phoneNumber;
            userDto.email = user.email;

            return userDto;

        }
        public static List<Dto.UserDto> ToDtoUserList(List<Dal.User> users)
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
