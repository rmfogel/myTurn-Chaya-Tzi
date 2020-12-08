using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Bl.Dal;
using Bl.BLModels;
using System.Data.Entity;

namespace Bl.Calcs
{
    //public enum WolkingBy{byFoot,byCar}


    public static class CalcRoute
    {
        public static Route Route { get; set; }
        private static Dictionary<ChoosenBusiness, List<ShiftDayDetail>> DictOrElse { get; set; }
        = new Dictionary<ChoosenBusiness, List<ShiftDayDetail>>();
        public static TurnResult Result { get; set; } = new TurnResult();
        /// <summary>
        /// פונקציה ראשית לטיפול בכל החישובים
        /// </summary>
        /// <param name="route"></param>
        //למיין לפי שעה
        public static TurnResult Calc(Route route)
        {
            Route = route;
            //קריאה לפונקציה שמחשבת מסלול ומחזירה list apointment
            getMainCalc();

            DistanceCalc.SetAddresses(Result.GoodApointments);
            Result.Origion = new PointOnMap(Route.areaRange.startingPoint);
            Result.Destination = new PointOnMap(Route.areaRange.destinationPoint);
            if (Result.GoodApointments.Count > 0)
            {
                if (Result.GoodApointments[0].hour.HasValue)
                {
                    int before = Bl.Calcs.DistanceCalc.GooglePlacesDuration(route.areaRange.startingPoint, Result.GoodApointments[0].Address.formatedAddress, route.walkingBy);

                    Result.ActualStartTime = Result.GoodApointments[0].hour.Value.AddMinutes(before * -1).TimeOfDay;
                }
                for (int i = Result.GoodApointments.Count-1; i >= 0; i--)
                {
                    if(Result.GoodApointments[i].hour.HasValue)
                    {
                        int after = Bl.Calcs.DistanceCalc.GooglePlacesDuration(route.areaRange.destinationPoint, Result.GoodApointments[i].Address.formatedAddress, route.walkingBy);
                        Result.ActualEndTime = Result.GoodApointments[i].hour.Value.AddMinutes(after).TimeOfDay;
                        break;
                    }

                }
            }

            return Result;

        }

       

        private static void getMainCalc()
        {
            DictOrElse = new Dictionary<ChoosenBusiness, List<ShiftDayDetail>>();
            Result = new TurnResult();
            CreateOrElseDict();
            if (DictOrElse.Count != 0)
            {
                PossibleCombinations.fillOptimalRoute(DictOrElse, Route);
                List<Dto.AppointmentDto> list = ApointmentBl.MakeApointmentsList(PossibleCombinations.OptimalRoute);
                Result.GoodApointments = list;
            }

        }
        /// <summary>
        /// שליפת כתובת הסניף מאוביקט התור
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>string adress</returns>
        private static void getAdressByApointent(Dto.AppointmentDto appointment)
        {
            //string adress;
            //try
            //{
            //    using (MyTurnEntities contex = new MyTurnEntities())
            //    {
            //        //todo: לבדוק שהאוביקט בטוח מתמלא לגמרי

            //        var Shift = contex.ShiftDayDetails.FirstOrDefault(sd => sd.id == appointment.);
            //        var idBranch = Shift.Shift.idBranch;
            //         adress = contex.Branches.FirstOrDefault(b => b.id == idBranch).adress;
            //    }
            //    return adress;
            //}
            //catch (Exception)
            //{

            //    throw new Exception
            //        ("there is error in appointment idAppointment:"+appointment.id);
            //}
        }


        //private void CreateCombination()
        //{
        //    for (int i = 0; i < MatOrElse.Count; i++)
        //    {
        //        CreatePossibleJourny(MatOrElse.ElementAt())
        //    }

        //}


        //}
        //TimeTake(TimeSpan start,TimeSpan end,int index)
        //{

        //}






        /// <summary>
        /// יוצר מטריצת סניפים אפשריים לבתי עסק נדרשים
        /// </summary>

        private static void CreateOrElseDict()
        {

            foreach (var item in Route.businesses)
            {
                bool goodBranchExists = false;
                List<ShiftDayDetail> branchesPossible = CreateBranchList(item, Route.areaRange, out goodBranchExists);
                //todo:  כאן לטפל במצב שחוזר רשימת סניפים אפשריים ריקה שלא היו בטווח  !
                // ולכן - או לבקש טווח אחר או לעשות חיפוש אחר - שהוא באיזה שהוא מרחק סביר מנקודת מוצא ולהודיע על חריגה או אולי להוריד את היעד
                if (branchesPossible.Count > 0)
                    DictOrElse.Add(item, branchesPossible);
                else
                {
                    var appointment = new AppointmentDto
                    {
                        Bussiness = Converters.BusinessConverter.ToDtoBusiness(item.business),
                        Service = Converters.ServiceConverter.ToDtoService(item.serviceChoosen),
                    };
                    if (goodBranchExists)
                    {
                        appointment.hour = GetEarliestTurn(item);
                        Result.NoFree.Add(appointment);
                    }
                    else

                        Result.NotGoodRange.Add(appointment);


                }

            }
        }
        /// <summary>
        /// בדיקה האם סניף מסוים נמצא בטווח המבוקש
        /// </summary>
        /// <param name="branch"></param>
        /// <returns>bool</returns>
        private static int IfBranchInTheRange(Branch branch)
        {
            // PolyUtil.isLocationOnPath(latLng, mPointsOfRoute, true, 10);
            var AB = DistanceCalc.GooglePlacesDuration(Route.areaRange.startingPoint, Route.areaRange.destinationPoint, Route.walkingBy);
            var AC = DistanceCalc.GooglePlacesDuration(Route.areaRange.startingPoint, branch.adress, Route.walkingBy);
            var BC = DistanceCalc.GooglePlacesDuration(branch.adress, Route.areaRange.destinationPoint, Route.walkingBy);
            return (AC + BC) - AB;





            //if (distance(A, C) + distance(B, C) == distance(A, B))
            //    return true; // C is on the line.
            //return false;    // C is not on the line.
        }

        /// <summary>
        /// מחזיר מערך סניפים אפשרי ספציפי לבית עסק מסוים
        /// </summary>
        /// <param name="business"></param>
        /// <param name="areaRange"></param>
        /// <returns></returns>
        private static List<ShiftDayDetail> CreateBranchList(ChoosenBusiness business, AreaRange areaRange, out bool goodTimeRange)
        {

            bool timeRange = false;

            List<ShiftDayDetail> branchesPossible = new List<ShiftDayDetail>();
            if (business.business.Branches == null || business.business.Branches.Count == 0)
            {
                goodTimeRange = false;
                return null;

            }
            else
            {
                foreach (var item in business.business.Branches)
                {

                    if (IfBranchInTheRange(item) < Route.timeRange.MinutesInRange)
                    {
                        timeRange = true;
                        ShiftDayDetail requiredDay = GetRequiredShiftDetailds(item.id, business.serviceChoosen.id);
                        if (requiredDay!=null&&IsExistsAvailAbleTurn(requiredDay))
                        {
                            branchesPossible.Add(requiredDay);
                        }

                    }

                }

            }
            goodTimeRange = timeRange;
            return branchesPossible;
        }

        private static DateTime? GetEarliestTurn(ChoosenBusiness business)
        {
            DateTime? earliestTurn = null;
            foreach (var item in business.business.Branches)
            {
                //todo Rachel have a good condition!!!
                var s = GetRequiredShiftDetailds(item.id, business.serviceChoosen.id);
                if (s != null)
                {
                    DateTime? closesed = ApointmentBl.GetClosesedApointment(Route.timeRange, s);
                    if (earliestTurn == null || earliestTurn < closesed)
                        earliestTurn = closesed;
                }
            }
            return earliestTurn;
        }

        /// <summary>
        ///- מחזיר את אוביקט המכיל את פרטי התור הדרוש
        ///  סניף , משמרת, שרות , יום בשבוע ושעות
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        private static ShiftDayDetail GetRequiredShiftDetailds(int branchId, int serviceId)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                ShiftDayDetail requiredDay = null;
                    var uu= contex.Branches.Include(b => b.Shifts).Include(b => b.Shifts.Select(s => s.Branch.Business)).Include(b => b.Shifts.Select(s => s.Service)).Include(b => b.Shifts.Select(s => s.ShiftDayDetails)).
                    Include(s => s.Shifts.Select(s1 => s1.ShiftDayDetails.Select(s2 => s2.Appointments))).FirstOrDefault(b => b.id == branchId).
                        Shifts.Where(s => s.idService == serviceId).ToList().SelectMany(s => s.ShiftDayDetails).ToList()
                        .Where(d => d.DayOfWeek == (int)Route.timeRange.StartingTime.Value.DayOfWeek);
                foreach (var d in uu)
                {
                    if (!((d.openTime > Route.timeRange.EndTime.Value.TimeOfDay) && d.ClosedTime < Route.timeRange.StartingTime.Value.TimeOfDay))
                    {
                        requiredDay = d;
                        break;
                    }

                }

                return requiredDay;
            }

        }
        /// <summary>
        /// האם יש תור פנוי באוביקט המכיל סניף, משמרת והשרות הדרוש
        /// </summary>
        /// <param name="requiredDay"></param>
        /// <returns></returns>
        private static bool IsExistsAvailAbleTurn(ShiftDayDetail requiredDay)
        {
            if (ApointmentBl.IsAvailableTurn(requiredDay, Route.timeRange))
                return true;
            return false;

        }



    }


}
