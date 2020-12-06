using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
   public class DayConverter
    {
        public static Dal.Day ToDalDay(Dto.DayDto dayDto)
        {
            Dal.Day day = new Day();
            day.id = dayDto.id;
            day.shiftId = dayDto.shiftId;
            day.zGrade = dayDto.zGrade;
            day.openTime = dayDto.openTime;
            day.ClosedTime = dayDto.ClosedTime;
            day.avgServiceTime = dayDto.avgServiceTime;
            

            return day;

        }
        public static List<Dal.Day> ToDalDayList(List<Dto.DayDto> dayListDto)
        {
            List<Dal.Day> dayListDal = new List<Day>();

            foreach (var item in dayListDto)
            {
                dayListDal.Add(ToDalDay(item));
            }
            return dayListDal;

        }

        public static Dto.DayDto ToDtoDay(Dal.Day day)
        {
            Dto.DayDto dayDto = new Dto.DayDto();

            dayDto.id = day.id;
            dayDto.shiftId = day.shiftId;
            dayDto.zGrade = day.zGrade;
            dayDto.openTime = day.openTime;
            dayDto.ClosedTime = day.ClosedTime;
            dayDto.avgServiceTime = day.avgServiceTime;
            return dayDto;

        }
        public static List<Dto.DayDto> ToDtoDayList(List<Dal.Day> days)
        {
            List<Dto.DayDto> daysDto = new List<Dto.DayDto>();

            foreach (var item in days)
            {
                daysDto.Add(ToDtoDay(item));
            }
            return daysDto;

        }
    }
}
