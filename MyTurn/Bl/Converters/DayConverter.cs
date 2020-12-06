using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;

namespace Bl.Converters
{
   public class DayConverter
    {
        public static ShiftDayDetail ToDalDay(Dto.ShiftDayDetailsDto dayDto)
        {
            ShiftDayDetail day = new ShiftDayDetail();
            day.id = dayDto.id;
            day.shiftId = dayDto.shiftId;
            day.zGrade = dayDto.zGrade;
            day.openTime = dayDto.openTime;
            day.ClosedTime = dayDto.ClosedTime;
            day.avgServiceTime = dayDto.avgServiceTime;
            

            return day;

        }
        public static List<ShiftDayDetail> ToDalDayList(List<Dto.ShiftDayDetailsDto> dayListDto)
        {
            List<ShiftDayDetail> dayListDal = new List<ShiftDayDetail>();

            foreach (var item in dayListDto)
            {
                dayListDal.Add(ToDalDay(item));
            }
            return dayListDal;

        }

        public static Dto.ShiftDayDetailsDto ToDtoDay(ShiftDayDetail day)
        {
            Dto.ShiftDayDetailsDto dayDto = new Dto.ShiftDayDetailsDto();

            dayDto.id = day.id;
            dayDto.shiftId = day.shiftId;
            dayDto.zGrade = day.zGrade;
            dayDto.openTime = day.openTime;
            dayDto.ClosedTime = day.ClosedTime;
            dayDto.avgServiceTime = day.avgServiceTime;
            return dayDto;

        }
        public static List<Dto.ShiftDayDetailsDto> ToDtoDayList(List<ShiftDayDetail> days)
        {
            List<Dto.ShiftDayDetailsDto> daysDto = new List<Dto.ShiftDayDetailsDto>();

            foreach (var item in days)
            {
                daysDto.Add(ToDtoDay(item));
            }
            return daysDto;

        }
    }
}
