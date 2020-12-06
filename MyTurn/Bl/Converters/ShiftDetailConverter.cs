using Bl.Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Converters
{
   public class ShiftDetailConverter
    {
        public static ShiftDayDetail ToDalShiftDetail(ShiftDayDetailsDto shiftDto)
        {
            ShiftDayDetail shift = new ShiftDayDetail();
            shift.id = shiftDto.id;
            shift.shiftId = shiftDto.shiftId;
            shift.avgServiceTime = shiftDto.avgServiceTime;
            shift.ClosedTime = shiftDto.ClosedTime;
            shift.DayOfWeek = shiftDto.dayName;
            shift.openTime = shiftDto.openTime;
            shift.zGrade = shiftDto.zGrade;



            return shift;

        }
        public static ShiftDayDetailsDto ToDtoShiftDetail(ShiftDayDetail shift)
        {
            ShiftDayDetailsDto shiftDto = new ShiftDayDetailsDto();
            shiftDto.id = shift.id;
            shiftDto.shiftId = shift.shiftId;
            shiftDto.avgServiceTime = shift.avgServiceTime;
            shiftDto.ClosedTime = shift.ClosedTime;
            shiftDto.dayName = shift.DayOfWeek.Value;
            shiftDto.openTime = shift.openTime;
            shiftDto.zGrade = shift.zGrade;

            return shiftDto;

        }

    }
}
