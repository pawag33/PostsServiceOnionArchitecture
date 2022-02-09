using ApplicationCore.DomainEntities.Models;

namespace Persistence.InMemoryDB.DbModels
{
    /// <summary>
    /// Db model needed to special functionality that related  only to db layer , like ORM functionality etc 
    /// </summary>
    public class PostDbModel
    {
        public string Title { get; init; }
        public string Content { get; init; }
    }
}
