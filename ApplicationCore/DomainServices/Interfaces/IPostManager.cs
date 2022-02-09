using System.Threading.Tasks;
using ApplicationCore.DomainEntities.Models;

namespace  ApplicationCore.DomainServices.Interfaces
{
  public interface IPostManager
    {
        Task CreatePost(Post post);
    }
}