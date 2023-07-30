using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public List<Comment> GetProvedCommentsByPostId(int postId)
        {
            using (var context=new BlogContext())
            {
                var comment = context.Comments.Where(x => x.PostId == postId && x.IsApproved).ToList();               
               
               if (comment!=null)
                {
                    return comment;
                }
                return null;
            }
        }
    }
}
