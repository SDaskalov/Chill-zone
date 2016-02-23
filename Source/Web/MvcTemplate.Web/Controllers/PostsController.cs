namespace ChillZone.Web.Controllers
{
    using System.Web.Mvc;
    using ChillZone.Services.Data;
    using ChillZone.Web.ViewModels.Home;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using System.Text.RegularExpressions;
    public class PostsController : BaseController
    {
        private readonly IPostsService posts;
        private readonly ICategoriesService postCategory;

        public PostsController(IPostsService posts, ICategoriesService postCategory)
        {
            this.posts = posts;
            this.postCategory = postCategory;
        }

        [HttpGet]
        public ActionResult Category(string name)
        {
           var category= this.postCategory.GetByName(name);
            var viewModel = this.Mapper.Map<PostCategoryViewModel>(category);
            return this.View(viewModel);
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

        [HttpGet]
        public ActionResult CreatePhoto()
        {
            var post = new PostViewModel
            {
                IsVideo = false
            };
            return this.PartialView("_PhotoPartial", post);
        }

        [HttpGet]
        public ActionResult CreateVIdeo()
        {
            var post = new PostViewModel
            {
                IsVideo = true
            };
            return this.PartialView("_VideoPartial", post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var categoryPostToAdd = this.postCategory.EnsureCategory(model.Category);
           var post = new Post()
            {
                IsVideo = model.IsVideo,
                SharedUrl = model.SharedUrl,
                Title = model.Title,
                Category = categoryPostToAdd,
                AuthorId = this.User.Identity.GetUserId()
             };
            categoryPostToAdd.Posts.Add(post);
            this.posts.Create(post);
            this.TempData["Notification"] = "Post Created!";
            return this.Redirect("/");
        }
    }
}
