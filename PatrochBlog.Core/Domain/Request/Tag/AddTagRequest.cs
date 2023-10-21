using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain.Request.Tag
{
    public class AddTagRequest
    {
        public string Title { get; set; } = string.Empty;
    }
}
