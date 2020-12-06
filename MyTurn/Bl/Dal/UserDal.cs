using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
    public class UserDal
    {
        public static List<User> GetUsers()
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.Users.ToList();
            }
        }

        public static User GetUser(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                    User user = ctx.Users.FirstOrDefault(u => u.id == id);
                    if (user != null)
                        return user;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static int CreateUser(Dto.UserDto user)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    User u = Bl.Converters.UserConveter.ToDalUser(user);
                    
                    contex.Users.Add(u);
                    if (u != null)
                    {
                        contex.SaveChanges();
                        return u.id;
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                //todo
                throw e;
            }


        }

        public static void UpdateUser(Dto.UserDto user)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    User q = contex.Users.FirstOrDefault(u => u.id == user.id);
                    if (q != null)
                    {
                        q.id = user.id;
                        q.firstName = user.firstName;
                        q.lastName = user.lastName;
                        q.email = user.email;
                        q.phoneNumber = user.phoneNumber;
                        contex.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void deleteUser(Dto.UserDto user)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    User q = contex.Users.FirstOrDefault(u => u.id == user.id);
                    if (q != null)
                        contex.Users.Remove(q);
                    contex.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static User logIn(string phoneNumber, string email)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                User u1 = contex.Users.FirstOrDefault(u => (u.phoneNumber == phoneNumber) && (u.email == u.email));
                return u1;
            }

        }
    }
}
