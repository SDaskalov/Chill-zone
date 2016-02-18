namespace ChillZone.Web.Controllers
{
    using System.Web.Mvc;

    using ChillZone.Services.Data;
    using ChillZone.Web.Infrastructure.Mapping;
    using ChillZone.Web.ViewModels.Home;

    public class PostsController : BaseController
    {
        private readonly IPostsService posts;

        public PostsController(
            IPostsService posts)
        {
            this.posts = posts;
        }

        public ActionResult ById(string id)
        {
            var post = this.posts.GetById(id);
            var viewModel = this.Mapper.Map<PostViewModel>(post);
            return this.View(viewModel);
        }
    }
}
