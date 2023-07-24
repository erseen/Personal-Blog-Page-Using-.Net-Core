using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Concrete
{
    public class EfCoreCategoryDal :
         EfCoreGenericDal<Category, BlogContext>, ICategoryDal
    {
        public int GetAllCategoriesCount()
        {
            using (var context = new BlogContext())
            {
                return context.Categories.Count(); 
            }
        }
    }
}
