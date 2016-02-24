﻿namespace ChillZone.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IPostsService posts;
        private readonly ICategoriesService postCategories;

        public HomeController(
            IPostsService posts,
            ICategoriesService postCategories)
        {
            this.posts = posts;
            this.postCategories = postCategories;
        }

        public ActionResult Index()
        {
            var posts = this.posts.GetLatestPosts(50).Where(x => x.IsDeleted == false).To<PostViewModel>().ToList();
            var categories = this.postCategories.GetAll().To<PostCategoryViewModel>().ToList();
            var viewModel = new IndexViewModel
            {
                Posts = posts,
                Categories = categories
            };

            return this.View(viewModel);
        }
    }
}
