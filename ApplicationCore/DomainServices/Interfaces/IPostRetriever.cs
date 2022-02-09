using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DomainEntities.Models;

namespace ApplicationCore.DomainServices.Interfaces
{   public interface IPostRetriever
    {
        Task<List<Post>> RetriveAllPosts();
    }
}