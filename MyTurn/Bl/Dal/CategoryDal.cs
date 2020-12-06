using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
   public class CategoryDal
    {
        public static List<Category> GetCategories()
        {
            using (MyTurnEntities db = new MyTurnEntities())
            {
                return db.Categories.ToList();
            }
        }

        public static int CreateCategory(Dto.CategoryDto category)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Category c1 = new Category()
                    { id = category.id, name = category.name };
                    contex.Categories.Add(c1);
                    contex.SaveChanges();
                    return c1.id;
                }
            }
            catch (Exception e)
            {
                //todo
                throw;
            }
            
            
        }

        public static void UpdateCategory(Dto.CategoryDto category)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Category q = contex.Categories.FirstOrDefault(c => c.id == category.id);
                    if (q != null)
                    {
                        q.id = category.id;
                        q.name = category.name;
                        contex.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
