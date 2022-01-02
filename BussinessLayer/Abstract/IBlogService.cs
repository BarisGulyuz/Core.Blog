﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
   public interface IBlogService: IGenericService<Blog>
    {
        List<Blog> GetListBlogWithCategory();
        List<Blog> GetBlogListWithWriter(int id);
        List<Blog> GetBlogListByWriter(int id);
    }
}
