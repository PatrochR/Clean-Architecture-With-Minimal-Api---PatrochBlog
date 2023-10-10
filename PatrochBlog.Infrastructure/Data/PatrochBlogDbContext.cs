using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PatrochBlog.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data
{
    public class PatrochBlogDbContext : DbContext
    {
        public PatrochBlogDbContext(DbContextOptions options ): base (options)
        {
            
        }

        public DbSet<Post> Posts { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Comment> Comments { get; set; } 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostTag> PostTags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<PatrochBlogDbContext>
    {
        public PatrochBlogDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<PatrochBlogDbContext>();
            optionBuilder.UseSqlite("Data Source=PatrochDb.db");

            return new PatrochBlogDbContext(optionBuilder.Options);
            
        }
    }
}
