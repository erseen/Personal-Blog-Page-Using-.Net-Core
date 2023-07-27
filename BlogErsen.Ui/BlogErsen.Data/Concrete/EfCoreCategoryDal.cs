using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public string GetCategoryNameById(int id)
        {
            using (var context = new BlogContext())
            {
               var category=  context.Categories.Where(x => x.CategoryId == id).AsQueryable();
                if (category!=null) 
                {
                    return category.Select(x => x.CategoryName).FirstOrDefault();
                
                }
                else
                {
                    return "Kategori Bulunamadı";
                }
            
            }
        }
    }
}
