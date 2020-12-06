using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
  public  class BranchBl
    {
        
            public static List<Dto.BranchDto> GetBranches( int idBusiness)
            {

                return Converters.BranchConverter.ToDtoBranchList
                (Dal.BranchDal.GetBranches(idBusiness));
            }
       
    }
    
}
