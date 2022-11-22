using ApplicationCore.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Repositories
{
    public interface IPostRepository
    {
        Task AddPost(Post post);

        Task<List<Post>> GetAllPosts();
    }
}
