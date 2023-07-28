using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Concrete
{
    public class EfCoreCommentDal :
         EfCoreGenericDal<Comment, BlogContext>, ICommentDal
    {
        public List<Comment> GetApprovedComments()
        {
            using (var context=new BlogContext())
            {
                return context.Comments.Where(x => x.IsApproved).ToList();
            }
        }
    }
}
