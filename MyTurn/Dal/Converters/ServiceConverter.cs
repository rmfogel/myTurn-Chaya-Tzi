using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    class ServiceConverter
    {
        public static Dal.Service ToDalService(Dto.ServiceDto serviceDto)
        {
            Dal.Service service = new Service();
            service.id = serviceDto.id;
            service.idCategory = serviceDto.idCategory;
            service.name = serviceDto.name;
            

            return service;

        }
        public static List<Dal.Service> ToDalServiceList(List<Dto.ServiceDto> serviceListDto)
        {
            List<Dal.Service> serviceListDal = new List<Service>();

            foreach (var item in serviceListDto)
            {
                serviceListDal.Add(ToDalService(item));
            }
            return serviceListDal;

        }

        public static Dto.ServiceDto ToDtoService(Dal.Service service)
        {
            Dto.ServiceDto serviceDto = new Dto.ServiceDto();

            serviceDto.id = service.id;
            serviceDto.idCategory = service.idCategory;
            serviceDto.name = service.name;
            return serviceDto;

        }
        public static List<Dto.ServiceDto> ToDtoServiceList(List<Dal.Service> serviceList)
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
