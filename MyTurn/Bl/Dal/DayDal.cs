using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
   public class DayDal
    {
        public static List<ShiftDayDetail> GetDays()
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.ShiftDayDetails.ToList();
            }
        }

        public static ShiftDayDetail GetDay(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                    ShiftDayDetail Day = ctx.ShiftDayDetails.FirstOrDefault(u => u.id == id);
                    if (Day != null)
                        return Day;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int CreateUser(Dto.ShiftDayDetailsDto day)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    ShiftDayDetail d = new ShiftDayDetail()
                    { id= day.id,avgServiceTime=day.avgServiceTime,ClosedTime=day.ClosedTime,openTime=day.openTime,shiftId=day.shiftId,zGrade=day.zGrade};
                    contex.ShiftDayDetails.Add(d);
                    contex.SaveChanges();
                    return d.id;
                }
            }
            catch (Exception e)
            {
                //todo
                throw;
            }


        }

        public static void UpdateDay(Dto.ShiftDayDetailsDto day)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    ShiftDayDetail q = contex.ShiftDayDetails.FirstOrDefault(u => u.id == day.id);
                    if (q != null)
                    {
                        q.id = day.id;
                        q.openTime = day.openTime;
                        q.shiftId = day.shiftId;
                        q.zGrade = day.zGrade;
                        q.ClosedTime = day.ClosedTime;
                        q.avgServiceTime = day.avgServiceTime;
                        contex.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void deleteDay(Dto.ShiftDayDetailsDto day)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    ShiftDayDetail q = contex.ShiftDayDetails.FirstOrDefault(u => u.id == day.id);
                    if (q != null)
                        contex.ShiftDayDetails.Remove(q);
                    contex.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
