using Microsoft.EntityFrameworkCore;
using PatrochBlog.Core.Domain;
using PatrochBlog.Core.Interfaces.Repository;
using PatrochBlog.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagDomain = PatrochBlog.Core.Domain.Tag;
using TagEntity = PatrochBlog.Infrastructure.Data.Entities.Tag;

namespace PatrochBlog.Infrastructure.Data.Repositories
{
    
    public class TagRepository : ITagRepository
    {
        private readonly PatrochBlogDbContext _context;

        public TagRepository(PatrochBlogDbContext context)
        {
            _context = context;
        }

        public Task<int> CreateTag(TagDomain tag)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTag(TagDomain tag)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TagDomain>> GetAllTags()
        {
            return await _context.Tags.Select(t => new TagDomain
            {
                Id = t.Id,
                CreatedTime = t.CreatedTime,
                Title = t.Title
            }).ToListAsync();
        }

        public async Task<TagDomain> GetTagById(int id)
        {
            var tag = await _context.Tags.Select(t => new TagDomain
            {
                Id = t.Id,
                CreatedTime = t.CreatedTime,
                Title = t.Title
            }).FirstOrDefaultAsync(t => t.Id == id);
            if(tag is null)
            {
                throw new Exception("Tag Is Not Exist!");
            }
            return tag;
        }
    }
}
