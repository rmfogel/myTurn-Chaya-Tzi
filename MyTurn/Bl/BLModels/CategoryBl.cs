using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class CategoryBl
    {
        public static List <Dto.CategoryDto> GetCategories()
        {
            
            
            return Converters.CategoryConverter.ToDtoCategoryList(Dal.CategoryDal.GetCategories());
        }
    }
}
