using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
    public class ServiceDal
    {
        public static List<ServiceDto> GetServices(int idBusiness)
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return Bl.Converters
                    .ServiceConverter
                    .ToDtoServiceList(ctx.Services.Where(s => s.businessId == idBusiness).ToList());
            }
        }

        public static List<ServiceDto> GetServicesForBranch(int branchId)
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return Bl.Converters
                    .ServiceConverter
                    .ToDtoServiceList(ctx.Services.Where(s => s.Shifts.Any(sh => sh.idBranch == branchId)).ToList());
            }
        }

        public static Service GetServiceById(int serviceId)
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.Services.FirstOrDefault(s => s.id == serviceId);

            }
        }
    }
}

