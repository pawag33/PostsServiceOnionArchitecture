using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DomainEntities.Models;
using DomainEntities.Repositories;
using Infrastructure.Persistence.InMemoryDB.DbModels;

namespace Infrastructure.Persistence.InMemoryDB.Repositories
{
    public class PostInMemoryRepository : IPostRepository
    {
        private List<PostDbModel> _posts = new List<PostDbModel>
         { 
            new PostDbModel{Title = "Title1",Content = "Blah blah"},
            new PostDbModel{Title = "Title2",Content = "Blah blah"},
            new PostDbModel{Title = "Title3",Content = "Blah blah"}
        };

        public Task<List<Post>> GetAllPosts()
        {
            return Task.FromResult(_posts.Select(x => new Post { Title = x.Title, Content = x.Content }).ToList());
        }

        public async Task AddPost(Post post)
        {
            // some persistence logic
            var postDbModel = new PostDbModel
            {
                Title = post.Title,
                Content = post.Content
            };
            _posts.Add(postDbModel);
            await Task.FromResult(1);
        }
    }
}
