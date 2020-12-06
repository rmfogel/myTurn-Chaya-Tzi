using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Bl.Dal
{
   public class BusinessDal
    {
        public static List<BusinessDto> GetBusinessesByCategory(int idCategory)
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return Bl.Converters
                    .BusinessConverter
                    .ToDtoBusinessList( ctx.Businesses.Where(b=>b.idCategory==idCategory).ToList());
            }
        }

        public static Business GetBusiness(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {

                    Business business = ctx.Businesses
                        .FirstOrDefault(u => u.id == id);
                    if (business != null)
                        return business;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int CreateBusiness(Dto.BusinessDto Business)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Business u1 = new Business()
                    { idCategory = Business.idCategory,
                        name = Business.name,
                        phoneNumber = Business.phoneNumber,
                        email = Business.email,
                        passward = Business.password
                    };
                    contex.Businesses.Add(u1);
                   contex.SaveChanges();
                    return u1.id;
                }


            }
            catch (Exception e)
            {
                throw e;
                
            }


        }

        public static int UpdateBusiness(Dto.BusinessDto Business)
        {
            int res =0;
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Business q = contex.Businesses.FirstOrDefault(u => u.id == Business.id);
                    if (q != null)
                    {
                        q.id = Business.id;
                        q.idCategory = Business.idCategory;
                        q.name = Business.name;
                        q.phoneNumber = Business.phoneNumber;
                        contex.SaveChanges();
                    }
                 

                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void deleteBusiness(Dto.BusinessDto Business)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Business q = contex.Businesses.FirstOrDefault(u => u.id == Business.id);
                    if (q != null)
                    {
                        contex.Businesses.Remove(q);
                        contex.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
       public static Business logIn(string password, string email)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                Business b1 = contex.Businesses.FirstOrDefault(b => (b.passward == password) && (b.email == b.email));
                return b1;
            }

        }

      




    }
}
