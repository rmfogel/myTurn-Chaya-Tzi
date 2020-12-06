using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
   public class ShiftDal
    {
        public static List<Shift> GetShifts()
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.Shifts.ToList();
            }
        }

        public static Shift GetShift(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                    Shift Shift = ctx.Shifts.FirstOrDefault(u => u.id == id);
                    if (Shift != null)
                        return Shift;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int CreateShift(Dto.ShiftDto Shift)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Shift s = new Shift()
                    { id=Shift.id,idBranch=Shift.idBranch,idService=Shift.idService,MinTimeToCancel=Shift.MinTimeToCancel,PaymentforCancel=Shift.PaymentforCancel};
                    contex.Shifts.Add(s);
                    contex.SaveChanges();
                    return s.id;
                }
            }
            catch (Exception e)
            {
                //todo
                throw;
            }


        }

        public static void UpdateShift(Dto.ShiftDto Shift)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Shift q = contex.Shifts.FirstOrDefault(u => u.id == Shift.id);
                    if (q != null)
                    {
                        q.id = Shift.id;
                        q.idBranch = Shift.idBranch;
                        q.idService = Shift.idService;
                        q.MinTimeToCancel = Shift.MinTimeToCancel;
                        q.PaymentforCancel = Shift.PaymentforCancel;
                      
                        contex.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int deleteShift(Dto.ShiftDto Shift)
        {
            int res = 0;
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Shift q = contex.Shifts.FirstOrDefault(u => u.id == Shift.id);
                    if (q != null)
                    {
                        contex.Shifts.Remove(q);
                        res = contex.SaveChanges();
                    }
                }
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public static int deleteShifts(List<Dto.ShiftDto> shifts)
        {
            int res = 0;
            try
            {
                foreach (var item in shifts)
                {
                  res+=  deleteShift(item);
                }
                return res;
            }
            
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
