using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    class BranchConverter
    {
        public static Dal.Branch ToDalBranch(Dto.BranchDto branchDto)
        {
            Dal.Branch branch = new Branch();
            branch.adress = branchDto.adress;
            branch.id = branchDto.id;
            branch.phoneNumber = branchDto.phoneNumber;
            branch.idBusiness = branchDto.idBusiness;
            
            return branch ;

        }
        public static List<Dal.Branch> ToDalBranchList(List<Dto.BranchDto> branchesDto)
        {
            List<Dal.Branch> branchessDal = new List<Branch>();

            foreach (var item in branchesDto)
            {
                branchessDal.Add(ToDalBranch(item));
            }
            return branchessDal;

        }

        public static Dto.BranchDto ToDtoBranch(Dal.Branch branch)
        {
            Dto.BranchDto branchDto = new Dto.BranchDto();
            branchDto.adress = branch.adress;
            branchDto.id = branch.id;
            branchDto.phoneNumber = branch.phoneNumber;
            branchDto.idBusiness = branch.idBusiness;
            return branchDto;

        }
        public static List<Dto.BranchDto> ToDtoBranchList(List<Dal.Branch> branches)
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
