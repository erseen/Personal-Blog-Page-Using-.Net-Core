using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUi.Business.Abstract
{
    public interface ICommentService
    {
        Comment GetById(int id);
        List<Comment> GetAll();
        void Create(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);
        List<Comment> GetApprovedComments();
    }
}
