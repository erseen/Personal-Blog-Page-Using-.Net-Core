﻿using BlogErsen.Data.Abstract;
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

        public int GetAllPostCount()
        {
            return _postDal.GetAllPostCount();
        }

        public Post GetById(int id)
        {
           return _postDal.GetById(id);
        }

        public List<Post> GetPostByCategoryId(int categoryId)
        {
            return _postDal.GetPostByCategoryId(categoryId);
        }

        public List<Post> GetPostByComment()
        {
            return _postDal.GetPostByComment();
        }

        public List<Post> GetSearchResult(string q)
        {
           return  _postDal.GetSearchResult(q);    
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
    }
}
