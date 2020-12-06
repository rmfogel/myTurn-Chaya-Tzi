using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl;
using Bl.Dal;

namespace Bl.Converters
{
  public  class BranchConverter
    {
        public static Branch ToDalBranch(Dto.BranchDto branchDto)
        {
            Branch branch = new Branch();
            branch.adress = branchDto.adress;
            branch.id = branchDto.id;
            branch.phoneNumber = branchDto.phoneNumber;
            branch.idBusiness = branchDto.idBusiness;
            
            return branch ;

        }
        public static List<Branch> ToDalBranchList(List<Dto.BranchDto> branchesDto)
        {
            List<Branch> branchessDal = new List<Branch>();

            foreach (var item in branchesDto)
            {
                branchessDal.Add(ToDalBranch(item));
            }
            return branchessDal;

        }

        public static Dto.BranchDto ToDtoBranch(Branch branch)
        {
            Dto.BranchDto branchDto = new Dto.BranchDto();
            branchDto.adress = branch.adress;
            branchDto.id = branch.id;
            branchDto.phoneNumber = branch.phoneNumber;
            branchDto.idBusiness = branch.idBusiness;
            return branchDto;

        }
        public static List<Dto.BranchDto> ToDtoBranchList(List<Branch> branches)
        {
            List<Dto.BranchDto> branchesDto = new List<Dto.BranchDto>();

            foreach (var item in branches)
            {
                branchesDto.Add(ToDtoBranch(item));
            }
            return branchesDto;

        }
    }
}
