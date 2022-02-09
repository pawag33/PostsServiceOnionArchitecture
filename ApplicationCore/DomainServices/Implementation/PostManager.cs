using ApplicationCore.DomainEntities.Models;
using ApplicationCore.DomainServices.Interfaces;
using DomainEntities.Repositories;
using System.Threading.Tasks;

namespace ApplicationCore.DomainServices.Implementation
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepository _postRepository;
        private readonly IContentModerator _contentModerator;

        public PostManager(IPostRepository postRepository, IContentModerator contentModerator)
        {
            _postRepository = postRepository;
            _contentModerator = contentModerator;
        }

        public async Task CreatePost(Post post)
        {
            // TODO : Add validation here

            _contentModerator.ModerateContent(post.Content);

            await _postRepository.AddPost(post);
        }

    }
}