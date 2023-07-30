using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using Microsoft.EntityFrameworkCore;
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

        public List<Post> GetPostByCategoryId(int categoryId)
        {
            using (var context =new BlogContext())
            {
                return context.Posts.Where(x => x.CategoryId == categoryId).ToList();
            }
        }

        public List<Post> GetPostByComment()
        {
            using (var context = new BlogContext())
            {
                var GetPostByComment = context.Posts
             .Where(post => context.Comments.Any(comment => comment.PostId == post.PostId))
             .ToList();

                return GetPostByComment;

            }
        }
    }
}
