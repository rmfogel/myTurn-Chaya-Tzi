using Bl.BLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;
using System.Data.Entity;

namespace Bl.Converters
{
 public  class ChoosenBusinessConverter
    {

        public static ChoosenBusiness ToChoosenBusiness(int serviceId)
        {
           
            ChoosenBusiness chBusiness = new ChoosenBusiness();
            Service service; Business business;
            try
            {
                
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                  
                  //ctx.Configuration.LazyLoadingEnabled = false;
                 

                    service = ctx.Services.Include(s=>s.Shifts).Include(b => b.Shifts.Select(s => s.ShiftDayDetails)).FirstOrDefault(s => s.id == serviceId);
                     business = ctx.Businesses.Include(b=>b.Branches).Include(b=>b.Category).Include(b=>b.Services).Include(b=>b.Branches.Select(r=>r.Shifts)).Include(r=>r.Branches.Select(b=>b.Shifts.Select(s=>s.ShiftDayDetails))).FirstOrDefault(b => b.id == service.businessId);
                    //todo:הוספנו בלית ברירה כי הגיע ריק
                    //business.Branches = ctx.Branches.Where(br => br.idBusiness == business.id).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
                throw;
            }
            chBusiness.business = business;
            chBusiness.serviceChoosen = service;
            return chBusiness;
        }

        public static List<ChoosenBusiness> ToChoosenBusinessList(List<int> serviceList)
        {
            List<ChoosenBusiness> choosenBusinesses = new List<ChoosenBusiness>();
            foreach (var item in serviceList)
            {
                choosenBusinesses.Add(ToChoosenBusiness(item));
            }
            return choosenBusinesses;
        }
    }
}
