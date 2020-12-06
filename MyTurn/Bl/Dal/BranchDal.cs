using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Bl.Dal
{
   public class BranchDal
    {
        public static List<Branch> GetBranches(int? idBusiness)
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.Branches.Where(b => b.idBusiness == idBusiness).ToList();

               
            }
        }

        public static Branch GetBranch(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                    Branch Branch = ctx.Branches.FirstOrDefault(u => u.id == id);
                    if (Branch != null)
                        return Branch;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int CreateBranch(Dto.BranchDto Branch)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Branch b = Bl.Converters.BranchConverter.ToDalBranch(Branch);

                    
                    contex.Branches.Add(b);
                    if (b != null)
                    {
                        contex.SaveChanges();
                        return b.id;
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                
                throw e;
            }


        }
        public static int updateBranches(List<Dto.BranchDto> branches)
        {
            int result = 0;
            foreach (var b in branches)
            {
                result += updateBranch(b);
            }
            return result;
        }
        public static int updateBranch(Dto.BranchDto Branch)
        {
            int result = 0;
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Branch q = contex.Branches.FirstOrDefault(u => u.id == Branch.id);
                    if (q != null)
                    {
                        q.id = Branch.id;
                        q.idBusiness = Branch.idBusiness;
                        q.phoneNumber = Branch.phoneNumber;
                        q.adress = Branch.adress;
                       
                    result =  contex.SaveChanges();
                    }
                    return result;

                }
            }
            catch (Exception e)
            {

                throw e;
               
            }

        }

        public static void deleteBranch(int? idBranch)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    var shifts = contex.Shifts.Where(sh => sh.idBranch == idBranch).ToList();

                   int res= Dal
                        .ShiftDal
                        .deleteShifts
                        (Bl.Converters.ShiftConverter.ToDtoShiftList(shifts));
                    Branch q = contex.Branches.FirstOrDefault(u => u.id == idBranch);
                    if (q != null)
                    
                        contex.Branches.Remove(q);
                        contex.SaveChanges();
                    
                   
                    //todo:כרגע במחיקת סניף נמחקים כל המשמרות בלי בקשת המשתמש
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
