using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        List<Comment> GetApprovedComments();



    }
}
