namespace ChillZone.Services.Data
{
    using System;
    using System.Linq;

    using ChillZone.Data.Common;
    using ChillZone.Data.Models;
    using ChillZone.Services.Web;

    public class PostsService : IPostsService
    {
        private readonly IDbRepository<Post> posts;
        private readonly IIdentifierProvider identifierProvider;

        public PostsService(IDbRepository<Post> posts, IIdentifierProvider identifierProvider)
        {
            this.posts = posts;
            this.identifierProvider = identifierProvider;
        }

        public Post GetById(int id)
        {
           // var intId = this.identifierProvider.DecodeId(id);
            var post = this.posts.GetById(id);
            return post;
        }

        public IQueryable<Post> GetRandomPosts(int count)
        {
            return this.posts.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public IQueryable<Post> GetLatestPosts(int count)
        {
            return this.posts.All().OrderByDescending(x => x.CreatedOn).Take(count);
        }

        public Post Create(Post post)
        {
            this.posts.Add(post);
            this.posts.Save();
            return post;
        }
    }
}
