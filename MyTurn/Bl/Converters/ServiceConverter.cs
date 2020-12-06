using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;


namespace Bl.Converters
{
   public class ServiceConverter
    {
        public static Service ToDalService(Dto.ServiceDto serviceDto)
        {
           Service service = new Service();
            service.id = serviceDto.id;
            service.businessId = serviceDto.businessId;
            service.name = serviceDto.name;
            

            return service;

        }
        public static List<Service> ToDalServiceList(List<Dto.ServiceDto> serviceListDto)
        {
            List<Service> serviceListDal = new List<Service>();

            foreach (var item in serviceListDto)
            {
                serviceListDal.Add(ToDalService(item));
            }
            return serviceListDal;

        }

        public static Dto.ServiceDto ToDtoService(Service service)
        {
            Dto.ServiceDto serviceDto = new Dto.ServiceDto();

            serviceDto.id = service.id;
            serviceDto.businessId = service.businessId;
            serviceDto.name = service.name;
            return serviceDto;

        }
        public static List<Dto.ServiceDto> ToDtoServiceList(List<Service> serviceList)
        {
            List<Dto.ServiceDto> serviceDtoList = new List<Dto.ServiceDto>();

            foreach (var item in serviceList)
            {
                serviceDtoList.Add(ToDtoService(item));
            }
            return serviceDtoList;

        }
    }
}
