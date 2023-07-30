using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUi.Business.Abstract
{
    public interface IPostService
    {
        Post GetById(int id);
        List<Post> GetAll();
        void Create(Post entity);
        void Update(Post entity);
        void Delete(Post entity);
        int GetAllPostCount();
        List<Post> GetPostByComment();
        List<Post> GetPostByCategoryId(int categoryId);
    }
}
