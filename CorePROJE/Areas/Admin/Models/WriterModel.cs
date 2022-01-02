using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePROJE.Areas.Admin.Models
{
    public class WriterModel
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public int BlogCount { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
