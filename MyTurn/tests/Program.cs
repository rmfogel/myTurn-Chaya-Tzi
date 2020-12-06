using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests.Calcs;

namespace tests
{
    class TestCalcJourney
    {
        public void checkAlgorithmCombin()
        {

            int[][] matrix = new int[][]
                {
                       new int[] { 1, 2, 3 },
                       new int[] { 4, 5, 6 },
                       new int[] { 7, 8, 9 }
                 };

            tests.Calcs.PossibleCombinations.combin2(0, matrix, null);
        }



      
        //    void loadBusiness()
        //    {
        //        ICollection<Dto.BranchDto> branchesMizrhi = new HashSet<Dto.BranchDto>()
        //        {
        //            new Dto.BranchDto(){id=1,adress="chazonIsh20",idBusiness=1,phoneNumber="123455"},
        //            new Dto.BranchDto(){id=2,adress="RabiAkiva30",idBusiness=1,phoneNumber="52335658"},
        //            new Dto.BranchDto(){id=3,adress="Tarfon",idBusiness=1,phoneNumber="8965"},


        //        };
        //        ICollection<Dto.BranchDto> branchesLeumy = new HashSet<Dto.BranchDto>()
        //        {
        //            new Dto.BranchDto(){id=1,adress="chazonIsh20",idBusiness=1,phoneNumber="123455"},
        //            new Dto.BranchDto(){id=2,adress="RabiAkiva30",idBusiness=1,phoneNumber="52335658"},
        //            new Dto.BranchDto(){id=3,adress="Tarfon",idBusiness=1,phoneNumber="8965"},


        //        };
        //        Dto.BusinessDto business1 = new Dto.BusinessDto()
        //        {
        //            id = 1,
        //            idCategory = 1,
        //            phoneNumber = "0548476595",
        //            email = "mz123@gmail.com",
        //            name = "mizrahy",
        //            password = "123446",
        //            Branches= branchDtos
        //        };
        //        Dto.BusinessDto business2 = new Dto.BusinessDto()
        //        {
        //            id = 2,
        //            idCategory = 1,
        //            phoneNumber = "0548476595",
        //            email = "mz123@gmail.com",
        //            name = "leumy",
        //            password = "123446",
        //            Branches = branchDtos
        //        };

        //    }
        //}
        class Program
        {
            //void load()
            //{
            //    Dto.UserDto userDto1 = new Dto.UserDto()
            //    { id = 1, fi = "zipy", phoneNumber = "0527193252", email = "zf7193252@gmail.com" };
            //    Dto.UserDto userDto2=new Dto.UserDto()
            //    { id = 2, name = "chaya", phoneNumber = "0527193252", email = "xc32572@gmail.com" };
            //    Dto.UserDto userDto3 = new Dto.UserDto()
            //    { id = 3, name = "yael", phoneNumber = "0527986523", email = "nf252@gmail.com" };
            //    Dto.UserDto userDto4 = new Dto.UserDto()
            //    { id = 4, name = "efrat", phoneNumber = "0548265978", email = "dc123@gmail.com" };
            //}
            static void Main(string[] args)
            {

                Bl.RouteDto route = new RouteDto();
                route.areaRange.startingPoint = "רבי עקיבא 10 בני ברק";
                route.areaRange.destinationPoint = "שדרות ירושלים רמת גן";
                route.businessList = new List<int> {1,2,3};
                route.timeRange.StartingTime = DateTime.Today+new TimeSpan(10,15,0);
              //  route.timeRange.StartingTime = DateTime.Today+new TimeSpan(13,15,0);
                route.timeRange.EndTime = route.timeRange.StartingTime.Value.AddHours(5);
                    Bl.Route r = Bl.Converters.RouteConverter.ToRoute(route);

                var Dict = Bl.Calcs.CalcRoute.Calc(r);
                    Console.ReadLine();

                
               

            }
        }
    }
}
