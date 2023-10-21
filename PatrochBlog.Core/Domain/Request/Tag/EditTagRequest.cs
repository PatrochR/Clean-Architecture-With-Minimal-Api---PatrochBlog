using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain.Request.Tag
{
    public class EditTagRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
