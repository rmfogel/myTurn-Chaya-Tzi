using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    class ShiftConverter
    {
        public static Dal.Shift ToDalShift(Dto.ShiftDto shiftDto)
        {
            Dal.Shift shift = new Shift();
            shift.id = shiftDto.id;
            shift.idBranch = shiftDto.idBranch;
            shift.idService = shiftDto.idService;
            shift.MinTimeToCancel = shiftDto.MinTimeToCancel;
            shift.PaymentforCancel = shiftDto.PaymentforCancel;
            

            return shift;

        }
        public static List<Dal.Shift> ToDalShiftList(List<Dto.ShiftDto> shiftListDto)
        {
            List<Dal.Shift> shiftListDal = new List<Shift>();

            foreach (var item in shiftListDto)
            {
                shiftListDal.Add(ToDalShift(item));
            }
            return shiftListDal;

        }

        public static Dto.ShiftDto ToDtoShift(Dal.Shift shift)
        {
            Dto.ShiftDto shiftDto = new Dto.ShiftDto();
            shiftDto.id = shift.id;
            shiftDto.idBranch = shift.idBranch;
            shiftDto.idService = shift.idService;
            shiftDto.MinTimeToCancel = shift.MinTimeToCancel;
            shiftDto.PaymentforCancel = shift.PaymentforCancel;


            return shiftDto;

        }
        public static List<Dto.ShiftDto> ToDtoShiftList(List<Dal.Shift> shiftList)
        {
            List<Dto.ShiftDto> shiftDtoList = new List<Dto.ShiftDto>();

            foreach (var item in shiftList)
            {
                shiftDtoList.Add(ToDtoShift(item));
            }
            return shiftDtoList;

        }
    }
}
