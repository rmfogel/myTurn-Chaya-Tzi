using Bl;
using Bl.Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Calcs
{
    public class PossibleCombinations
    {
        private static int counter = 0;

        public static void combin2(int depth, int[][] matrix, int[] output)
        {
            int[] row = matrix[depth];

            if (depth == 0)
            {
                counter = 0;
                output = new int[matrix.Length];
                Console.WriteLine("matrix.lengh:" + matrix.Length);
            }

            for (int i = 0; i < row.Length; i++)
            {
                output[depth] = row[i];

                if (depth == (matrix.Length - 1))
                {
                    //print the combination
                    Console.WriteLine(output);
                    counter++;
                }
                else
                {
                    //recursively generate the combination
                    combin2(depth + 1, matrix, output);
                }
            }
        }

        public static Dictionary<ChoosenBusiness, List<Branch>> loadDictinary()
        {
            Business b1 = new Business() { name = "a", id = 1 };
            Business b2 = new Business() { name = "b", id = 2 };
            Business b3 = new Business() { name = "c", id = 3 };
            Service s1 = new Service() { id = 50, name = "sss" };
            ChoosenBusiness c1 = new ChoosenBusiness() { business = b1, serviceChoosen = s1 };
            ChoosenBusiness c2 = new ChoosenBusiness() { business = b2, serviceChoosen = s1 };
            ChoosenBusiness c3 = new ChoosenBusiness() { business = b3, serviceChoosen = s1 };

            Branch br1 = new Branch() { id = 1, adress = "א" };
            Branch br2 = new Branch() { id = 2, adress = "ב" };
            Branch br3 = new Branch() { id = 3, adress = "ג" };
            Branch br4 = new Branch() { id = 4, adress = "ד" };
            Branch br5 = new Branch() { id = 5, adress = "ה" };
            Branch br6 = new Branch() { id = 6, adress = "ו" };
            List<Branch> branches1 = new List<Branch>();
            List<Branch> branches2 = new List<Branch>();
            List<Branch> branches3 = new List<Branch>();
            branches1.Add(br1);
            branches1.Add(br2);
            branches2.Add(br3);
            branches2.Add(br4);
            branches3.Add(br5);
            branches3.Add(br6);




            Dictionary<ChoosenBusiness, List<Branch>> branchesOfBusinessDict =
                new Dictionary<ChoosenBusiness, List<Branch>>();
            branchesOfBusinessDict.Add(c1, branches1);
            branchesOfBusinessDict.Add(c2, branches2);
            branchesOfBusinessDict.Add(c3, branches3);
            return branchesOfBusinessDict;
        }
        
    }
}