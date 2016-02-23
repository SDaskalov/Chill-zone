namespace ChillZone.Web.Controllers
{
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using ChillZone.Services.Data;
    using ChillZone.Web.ViewModels.Home;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Data.Models;

    public class PostsController : BaseController
    {
        private readonly IPostsService posts;
        private readonly ICategoriesService postCategory;
        private readonly ICommentsService postComments;
        private readonly IPointsService postPoints;

        public PostsController(IPostsService posts, ICategoriesService postCategory, ICommentsService postComments,IPointsService postPoints)
        {
            this.posts = posts;
            this.postCategory = postCategory;
            this.postComments = postComments;
            this.postPoints = postPoints;
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
            // TODO:Regex for embeded url
            var post = new PostViewModel
            {
                IsVideo = true
            };
            return this.PartialView("_VideoPartial", post);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Like(PostViewModel model)
        {
            var point = new Point()
            {
                Value = 1,
                PostId = model.Id,
                AuthorId = this.User.Identity.GetUserId()
            };
            this.postPoints.Add(point);
            return this.Redirect("/");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Dislike(PostViewModel model)
        {
            var point = new Point()
            {
                Value = -1,
                PostId = model.Id,
                AuthorId = this.User.Identity.GetUserId()
            };
            this.postPoints.Add(point);
            return this.Redirect("/");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(PostViewModel model)
        {
            var comment = new Comment
            {
                Content = model.NewComment.Content,
                AuthorId = this.User.Identity.GetUserId(),
                PostId = model.Id
            };
            this.postComments.Add(comment);
            return this.Redirect(string.Format("/Post/{0}", model.Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
