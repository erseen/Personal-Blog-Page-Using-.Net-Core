using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Concrete
{
    public class EfCorePostDal :
           EfCoreGenericDal<Post, BlogContext>, IPostDal
    {
        public int GetAllPostCount()
        {
            using (var context = new BlogContext())
            {
                return context.Posts.Count();
            }
        }
    }
}
