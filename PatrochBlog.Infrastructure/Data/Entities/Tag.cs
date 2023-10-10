using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; } =string.Empty;
        public DateTime CreatedTime { get; set; }

        public IEnumerable<PostTag> PostTags { get; set; } = Enumerable.Empty<PostTag>();

    }


    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(50);
        }
    }
}
