using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain
{
    public class PostTag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }

        public Post Post { get; set; } = new Post();
        public Tag Tag { get; set; } = new Tag();
    }
}
