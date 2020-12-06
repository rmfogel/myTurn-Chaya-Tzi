using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
  public  class CancelationDal
    {
    //    public static List<Cancelation> GetCancelations()
    //    {
    //        using (MyTurnEntities ctx = new MyTurnEntities())
    //        {
    //            return ctx.Cancelations.ToList();
    //        }
    //    }

    //    public static Cancelation GetCancelation(int id)
    //    {
    //        try
    //        {
    //            using (MyTurnEntities ctx = new MyTurnEntities())
    //            {
    //                Cancelation Cancelation = ctx.Cancelations.FirstOrDefault(u => u.appoinmentId == id);
    //                if (Cancelation != null)
    //                    return Cancelation;
    //                return null;
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }

    //    public static int CreateUser(Dto.UserDto user)
    //    {
    //        try
    //        {
    //            using (MyTurnEntities contex = new MyTurnEntities())
    //            {
    //                User u1 = new User()
    //                { id = user.id, name = user.name, email = user.email, phoneNumber = user.phoneNumber };
    //                contex.Users.Add(u1);
    //                contex.SaveChanges();
    //                return u1.id;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            //todo
    //            throw;
    //        }


    //    }

    //    public static void UpdateUser(Dto.UserDto user)
    //    {
    //        try
    //        {
    //            using (MyTurnEntities contex = new MyTurnEntities())
    //            {
    //                User q = contex.Users.FirstOrDefault(u => u.id == user.id);
    //                if (q != null)
    //                {
    //                    q.id = user.id;
    //                    q.name = user.name;
    //                    q.email = user.email;
    //                    q.phoneNumber = user.phoneNumber;
    //                    contex.SaveChanges();
    //                }


    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }

    //    public static void deleteUser(Dto.UserDto user)
    //    {
    //        try
    //        {
    //            using (MyTurnEntities contex = new MyTurnEntities())
    //            {
    //                User q = contex.Users.FirstOrDefault(u => u.id == user.id);
    //                if (q != null)
    //                    contex.Users.Remove(q);
    //                contex.SaveChanges();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }
    }
}
