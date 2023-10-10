using PatrochBlog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task<int> AddCategory(Category category);
        Task EditCategory(Category category);
        Task DeleteCategory(int id);
    }
}
