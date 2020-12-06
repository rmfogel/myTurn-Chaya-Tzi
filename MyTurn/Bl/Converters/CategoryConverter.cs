using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;

namespace Bl.Converters
{
    public class CategoryConverter
    {
        public static Category ToDalCategory(Dto.CategoryDto categoryDto)
        {
            Category category = new Category();
            category.id = categoryDto.id;
            category.name = categoryDto.name;
            return category;

        }
        public static List<Category> ToDalCategoryList(List<Dto.CategoryDto> categoryListDto)
        {
            List<Category> categories = new List<Category>();

            foreach (var item in categoryListDto)
            {
                categories.Add(ToDalCategory(item));
            }
            return categories;

        }

        public static Dto.CategoryDto ToDtoCategory(Category category)
        {
            Dto.CategoryDto categoryDto = new Dto.CategoryDto();
            categoryDto.id = category.id;
            categoryDto.name = category.name;
            return categoryDto;

        }
        public static List<Dto.CategoryDto> ToDtoCategoryList(List<Category> categories)
        {
            List<Dto.CategoryDto> categoryListDto = new List<Dto.CategoryDto>();

            foreach (var item in categories)
            {
                categoryListDto.Add(ToDtoCategory(item));
            }
            return categoryListDto;

        }
    }
}
