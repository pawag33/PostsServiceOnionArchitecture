using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DomainEntities.Models;
using ApplicationCore.DomainServices.Interfaces;
using DomainEntities.Repositories;

namespace ApplicationCore.DomainServices.Implementation
{
    public class PostRetriever : IPostRetriever
    {
        private readonly IPostRepository _postRepository;

        public PostRetriever(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> RetriveAllPosts()
        {
           return await _postRepository.GetAllPosts();
        }
    }
}
