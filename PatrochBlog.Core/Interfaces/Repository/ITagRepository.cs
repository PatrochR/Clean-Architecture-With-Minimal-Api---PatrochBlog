using PatrochBlog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Interfaces.Repository
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int id);    
        Task<int> CreateTag(Tag tag);
        Task EditTag(Tag tag);
        Task DeleteTag(int id);

    }
}
