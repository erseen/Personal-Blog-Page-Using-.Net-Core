﻿using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Abstract
{
    public interface IPostDal:IGenericDal<Post>
    {
        int GetAllPostCount();
        List<Post> GetPostByComment();

    }
}
