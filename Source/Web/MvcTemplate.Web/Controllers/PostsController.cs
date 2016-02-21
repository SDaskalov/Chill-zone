namespace ChillZone.Web.Controllers
{
    using System.Web.Mvc;
    using ChillZone.Services.Data;
    using ChillZone.Web.ViewModels.Home;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class PostsController : BaseController
    {
        private readonly IDbRepository<Post> posts;
        private readonly IDbRepository<PostCategory> postCategory;

        public PostsController(IDbRepository<Post> posts, IDbRepository<PostCategory> postCategory)
        {
            this.posts = posts;
            this.postCategory = postCategory;
        }
       
        [HttpGet]
        public ActionResult ById(int id)
        {
            var post = this.posts.GetById(id);
            var viewModel = this.Mapper.Map<PostViewModel>(post);
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var category = new PostCategory()
            {
                Name = model.Category
            };
            var post = new Post()
            {
                SharedPhotoUrl = model.SharedPhotoUrl
            };
            if (this.User.Identity.IsAuthenticated)
            {
            post.AuthorId = this.User.Identity.GetUserId();
            }

            post.Category = category;
            category.Posts.Add(post);
            this.postCategory.Save();
            this.TempData["Notification"] = "Post Created!";
            return this.Redirect("/");
        }
    }
}
