using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
   public class BusinessConverter
    {
        public static Dal.Business ToDalBusiness(Dto.BusinessDto businessDto)
        {
            Dal.Business business = new Business();
            business.id = businessDto.id;
            business.idCategory = businessDto.idCategory;
            business.name = businessDto.name;
            business.phoneNumber = businessDto.phoneNumber;

            return business;

        }
        public static List<Dal.Business> ToDalBusinessList(List<Dto.BusinessDto> businessListDto)
        {
            List<Dal.Business> businessListDal = new List<Business>();

            foreach (var item in businessListDto)
            {
                businessListDal.Add(ToDalBusiness(item));
            }
            return businessListDal;

        }

        public static Dto.BusinessDto ToDtoBusiness(Dal.Business business)
        {
            if (business == null)
                return null;
            Dto.BusinessDto businessDto = new Dto.BusinessDto();
            businessDto.id = business.id;
            businessDto.idCategory = business.idCategory;
            businessDto.name = business.name;
            businessDto.phoneNumber = business.phoneNumber;

            return businessDto;

        }
        public static List<Dto.BusinessDto> ToDtoBusinessList(List<Dal.Business> businesses )
        {
            List<Dto.BusinessDto> businessListDto = new List<Dto.BusinessDto>();

            foreach (var item in businesses)
            {
                businessListDto.Add(ToDtoBusiness(item));
            }
            return businessListDto;

        }
    }
}
