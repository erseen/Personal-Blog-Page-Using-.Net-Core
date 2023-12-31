﻿using BlogErsen.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        int GetAllCategoriesCount();
       string GetCategoryNameById(int id); 
    }
}
