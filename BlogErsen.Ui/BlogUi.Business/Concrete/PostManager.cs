using BlogErsen.Data.Abstract;
using BlogErsen.Entity;
using BlogUi.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUi.Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
            
        }
        public void Create(Post entity)
        {
           _postDal.Create(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public List<Post> GetAll()
        {
         return   _postDal.GetAll();
        }

        public Post GetById(int id)
        {
           return _postDal.GetById(id);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
    }
}
