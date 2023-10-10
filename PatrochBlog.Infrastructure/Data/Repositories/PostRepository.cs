using Microsoft.EntityFrameworkCore;
using PatrochBlog.Core.Domain;
using PatrochBlog.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PatrochBlogDbContext _context;

        public PostRepository(PatrochBlogDbContext context)
        {
            _context = context;
        }
        public async Task<List<Post>> GetLatestPosts(int count)
        {
            return await _context.Posts.Select(x => new Post
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
            })
            .OrderByDescending(x => x.CreatedDate)
            .Take(count)
            .ToListAsync();
        }
    }
}
