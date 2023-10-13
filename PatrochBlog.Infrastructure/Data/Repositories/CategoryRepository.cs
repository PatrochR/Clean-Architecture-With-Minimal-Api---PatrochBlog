using Microsoft.EntityFrameworkCore;
using PatrochBlog.Core.Domain;
using PatrochBlog.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryDomain = PatrochBlog.Core.Domain.Category;
using CategoryEntity = PatrochBlog.Infrastructure.Data.Entities.Category;

namespace PatrochBlog.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PatrochBlogDbContext _context;

        public CategoryRepository(PatrochBlogDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCategory(CategoryDomain category)
        {
            var dbModel = new CategoryEntity()
            {
                Title = category.Title,
                CreatedDate = DateTime.Now,
            };
            await _context.Categories.AddAsync(dbModel);
            _context.SaveChanges();
            return dbModel.Id;
        }

        public async Task DeleteCategory(int id)
        {
            var finded = await GetCategory(id);
            _context.Categories.Remove(finded);
            _context.SaveChanges();
        }

        public async Task EditCategory(CategoryDomain category)
        {
            var finded = await GetCategory(category.Id);
            finded.Title = category.Title;
            _context.Categories.Update(finded);
            _context.SaveChanges(); 
            
        }

        public async Task<List<CategoryDomain>> GetAllCategory()
        {
            return await _context.Categories.Select(x => new CategoryDomain {
                Id = x.Id,
                CreatedDate= x.CreatedDate,
                Title = x.Title
            }).ToListAsync();

        }

        public  async Task<CategoryDomain> GetCategoryById(int id)
        {
            var category = await _context.Categories.Select(x => new CategoryDomain
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate
            }).FirstOrDefaultAsync(x => x.Id == id);

            if(category is null)
            {
                throw new Exception("Not Found");
            }

            return category;
        }

        private async Task<CategoryEntity> GetCategory(int id)
        {
            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null) 
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
