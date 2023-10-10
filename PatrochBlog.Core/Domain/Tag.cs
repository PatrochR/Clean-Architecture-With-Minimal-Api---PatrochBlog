using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; } =string.Empty;
        public DateTime CreatedTime { get; set; }

        public IEnumerable<PostTag> PostTags { get; set; } = Enumerable.Empty<PostTag>();

    }
}
