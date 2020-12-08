using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;

namespace Bl.Converters
{
   public class BusinessConverter
    {
        public static Business ToDalBusiness(Dto.BusinessDto businessDto)
        {
            Business business = new Business();
            business.id = businessDto.id;
            business.idCategory = businessDto.idCategory;
            business.name = businessDto.name;
            business.phoneNumber = businessDto.phoneNumber;
            business.email = businessDto.email;
            business.passward = businessDto.password;
            business.image = businessDto.image;

            return business;

        }
        public static List<Business> ToDalBusinessList(List<Dto.BusinessDto> businessListDto)
        {
            List<Business> businessListDal = new List<Business>();

            foreach (var item in businessListDto)
            {
                businessListDal.Add(ToDalBusiness(item));
            }
            return businessListDal;

        }

        public static Dto.BusinessDto ToDtoBusiness(Business business)
        {
            if (business == null)
                return null;
            Dto.BusinessDto businessDto = new Dto.BusinessDto();
            businessDto.id = business.id;
            businessDto.idCategory = business.idCategory;
            businessDto.name = business.name;
            businessDto.phoneNumber = business.phoneNumber;
            businessDto.email = business.email;
            businessDto.password = business.passward;
            businessDto.image = business.image;
            return businessDto;

        }
        public static List<Dto.BusinessDto> ToDtoBusinessList(List<Business> businesses )
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
