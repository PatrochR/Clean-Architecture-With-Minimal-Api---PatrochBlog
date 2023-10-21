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

        public async Task<int> AddTag(TagDomain tag)
        {
            var dbModel = new TagEntity()
            {
                CreatedTime = DateTime.Now,
                Title = tag.Title,
                Id = tag.Id,
            };
            await _context.SaveChangesAsync();
            return tag.Id;
        }

        public async Task DeleteTag(int id)
        {
            var tag = await GetTagAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task EditTag(TagDomain tag)
        {
            var oldTag = await GetTagAsync(tag.Id);
            oldTag.Title = tag.Title;
            _context.Tags.Update(oldTag);
            await _context.SaveChangesAsync();
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

        private async Task<TagEntity> GetTagAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if(tag is null ) 
            {
                throw new Exception("Not Found!");
            }
            return tag;
        }
    }
}
