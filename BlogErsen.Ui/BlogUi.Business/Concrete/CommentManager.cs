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
    public class CommentManager : ICommentService
    {

        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal=commentDal;
        }
        public void Create(Comment entity)
        {
           _commentDal.Create(entity);

        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetApprovedComments()
        {
            return _commentDal.GetApprovedComments();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
