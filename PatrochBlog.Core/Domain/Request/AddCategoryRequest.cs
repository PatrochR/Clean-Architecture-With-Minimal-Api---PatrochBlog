using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain.Request
{
    public class AddCategoryRequest
    { 
        public string Title { get; set; } = string.Empty;
    }
}
