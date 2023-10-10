using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data.Entities
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

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(50);

            builder.Property(p => p.Content)
                .HasMaxLength(1000);
        }
    }
}
