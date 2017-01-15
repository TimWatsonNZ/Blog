using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class WritePostVm
    {
        public bool IsUpdate { get; set; }
        public BlogPostVm BlogPost { get; set; }
    }
}