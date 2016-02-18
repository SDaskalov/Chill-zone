namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> GetRandomPosts(int count);

        IQueryable<Post> GetLatestPosts(int count);

        Post GetById(string id);
    }
}
