using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class CategoryConverter
    {
        public static Dal.Category ToDalCategory(Dto.CategoryDto categoryDto)
        {
            Dal.Category category = new Category();
            category.id = categoryDto.id;
            category.name = categoryDto.name;
            return category;

        }
        public static List<Dal.Category> ToDalCategoryList(List<Dto.CategoryDto> categoryListDto)
        {
            List<Dal.Category> categories = new List<Category>();

            foreach (var item in categoryListDto)
            {
                categories.Add(ToDalCategory(item));
            }
            return categories;

        }

        public static Dto.CategoryDto ToDtoCategory(Dal.Category category)
        {
            Dto.CategoryDto categoryDto = new Dto.CategoryDto();
            categoryDto.id = category.id;
            categoryDto.name = category.name;
            return categoryDto;

        }
        public static List<Dto.CategoryDto> ToDtoCategoryList(List<Dal.Category> categories)
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
