using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; } =string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = new Category();
        public IEnumerable<Comment> Comments { get; set; } = Enumerable.Empty<Comment>();
        public IEnumerable<PostTag> PostTags { get; set; } = Enumerable.Empty<PostTag>();
    }
}
