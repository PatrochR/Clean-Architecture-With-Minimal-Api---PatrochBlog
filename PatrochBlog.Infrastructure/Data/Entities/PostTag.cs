using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data.Entities
{
    public class PostTag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }

        public Post Post { get; set; } = new Post();
        public Tag Tag { get; set; } = new Tag();
    }

    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("Post_Tag");
            builder.HasKey(x => x.Id);

            builder.HasOne(pt => pt.Post).WithMany(p => p.PostTags);
            builder.HasOne(pt => pt.Tag).WithMany(t => t.PostTags);
        }
    }
}

