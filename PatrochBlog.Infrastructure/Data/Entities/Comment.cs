using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = string.Empty;

        public int PostId { get; set; }
        public Post Post { get; set; } = new Post();
    }
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(50);
            builder.Property(c => c.Content)
                .HasMaxLength(150);

            builder.HasOne(c => c.Post).WithMany(p => p.Comments);
        }
    }
}
