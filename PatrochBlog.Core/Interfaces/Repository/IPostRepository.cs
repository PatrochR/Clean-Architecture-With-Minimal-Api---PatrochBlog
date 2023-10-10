using PatrochBlog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrochBlog.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<List<Post>> GetLatestPosts(int count);  

    }
}
