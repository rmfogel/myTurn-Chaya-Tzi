using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;
using Bl.BLModels;

namespace Bl.Calcs
{
    public class PossibleCombinations
    {

        private static int counter = 0;

        public static int MinTimeTake { get; set; } = 0;
        public static List<OptionalShift> OptimalRoute { get; set; }
        public static List<OptionalShift> TempRout { get; set; } = new List<OptionalShift>();
        public static Route currentRoute { get; set; }
        public Dictionary<int, Service> ServicesIndexes { get; set; }

        public static void fillOptimalRoute(Dictionary<ChoosenBusiness, List<ShiftDayDetail>> BusinessBranchesDict, Route route)
        {
            currentRoute = route;
            var matrix = ToMatrix(BusinessBranchesDict);
            if (matrix.Length == 0)
                return;
            PossibleMat(0, matrix, null);
        }

        //למטריצה dictionary - המרת ה- 
        public static ShiftDayDetail[][] ToMatrix(Dictionary<ChoosenBusiness, List<ShiftDayDetail>> BusinessBranchesDict)
        {
            ShiftDayDetail[][] branches = new ShiftDayDetail[BusinessBranchesDict.Keys.Count][];

            int i = 0;

            for (i = 0; i < BusinessBranchesDict.Keys.Count; i++)
            {
                ChoosenBusiness business = BusinessBranchesDict.Keys.ElementAt(i);
                //todo לא נמצאו נתונים לאחד המערכים במטרחצה
                if (BusinessBranchesDict[business].Count == 0)
                    continue;
                branches[i] = new ShiftDayDetail[BusinessBranchesDict[business].Count];
                for (int j = 0; j < BusinessBranchesDict[business].Count; j++)
                {

                    branches[i][j] = BusinessBranchesDict[business][j];
                }
            }

            Console.WriteLine("=================old matrix");
            //foreach (var item in branches)
            //{
            //    TempPrint(item);
            //}
            Console.WriteLine("====================");

            return branches;
        }
        public static int[][] tempMatIdBranch { get; set; }



        /// <summary>
        /// פונקציה רקורסיבית למעבר על כל הצרופים 
        /// האפשריים של המסלולים במטריצת הסניפים
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="matrix"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static void PossibleMat(int depth, ShiftDayDetail[][] matrix, ShiftDayDetail[] output)
        {
            ShiftDayDetail[] row = matrix[depth];

            if (depth == 0)
            {
                counter = 0;
                output = new ShiftDayDetail[matrix.Length];
                Console.WriteLine("matrix.lengh:" + matrix.Length);
            }

            for (int i = 0; i < row.Length; i++)
            {
                output[depth] = row[i];

                if (depth == (matrix.Length - 1))
                {
                    //print the combination
                    //calculate time 
                    //save time on combination 
                    //לתת ללקוח להחליט אם לראות מספר אפשרוית
                    //min

                    Calc_Time_In_Each_Combinaton_Of_Route(output);
                    // TempPrint(output);
                    counter++;
                }
                else
                {
                    // tempMatIdBranch[depth][i]=output[]
                    //recursively generate the combination
                    PossibleMat(depth + 1, matrix, output);
                }
            }
        }

        private static void TempPrint(Branch[] branch)
        {
            foreach (var item in branch)
            {
                Console.Write(item.id + " " + item.adress.ToString());
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// מקבלת רשימה של סניפים המוכלים באוביקט פרטי היום 
        /// ועוברת על כל הסידורים האפשריים לצרוף זה של סניפים
        ///תוך חישוב זמן כולל של המסלול ושמירת המסלול האופטימלי
        /// </summary>
        /// <param name="days"></param>
        /// <param name="startTime"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        private static void Calc_Time_In_Each_Combinaton_Of_Route(ShiftDayDetail[] days)
        {

            TempRout.Clear();
            int count = days.Length;
            int timeTake = 0;
            TimeSpan? availableTurn = null;
            DateTime time = currentRoute.timeRange.StartingTime.Value;
            string startingPoint = currentRoute.areaRange.startingPoint;


            for (int index = 0; index < count; index++)
            {
                //for (int j = 0; j < count; j++)
                //{
                //    index = (i + j) % count;

                //חישוב זמן הליכה או נסיעה מנק' נוכחית לנק' הבאה
                time = time.Date + time.TimeOfDay.Add(new TimeSpan(0, Calcs.DistanceCalc.GooglePlacesDuration(startingPoint, days.ElementAt(index).Shift.Branch.adress, currentRoute.walkingBy), 0));

                //מחזיר שעה של התור הנוכחי
                availableTurn = ApointmentBl.GetFirstAvailableTurn(days.ElementAt(index), new TimeRange { StartingTime = time, EndTime = currentRoute.timeRange.EndTime.Value });

                if (availableTurn == null)
                {// לטפל - מצב בו אין תור פנוי בסניף זה בשעה הרצויה   
                    break;

                }
                OptionalShift optional = new OptionalShift();
                optional.AvilableTime = availableTurn.Value;
                optional.Shift = days.ElementAt(index);
                optional.ServiceId = days.ElementAt(index).Shift.Service.id;
                TempRout.Add(optional);
                time = time.Date + ((TimeSpan)availableTurn);

                //todo:  זמן המתנה ממוצע 
                //time.StartingTime.Value.TimeOfDay.Add(new TimeSpan(0, (int)(days.ElementAt(index).), 0);
                //מוסיף זמן ממוצע של זמן השרות
                time = time + new TimeSpan(0, (int)(days.ElementAt(index).avgServiceTime), 0);
                startingPoint = days.ElementAt(index).Shift.Branch.adress;
            }
            timeTake = (int)(time.TimeOfDay - currentRoute.timeRange.StartingTime.Value.TimeOfDay).TotalMinutes;
            if (timeTake < MinTimeTake || MinTimeTake == 0)
            {
                MinTimeTake = timeTake;
                OptimalRoute = TempRout;
            }



            //}


        }
    }
}
