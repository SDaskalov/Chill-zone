﻿namespace ChillZone.Web.Controllers
{
    using System.Web.Mvc;

    using ChillZone.Services.Data;
    using ChillZone.Web.Infrastructure.Mapping;
    using ChillZone.Web.ViewModels.Home;

    public class JokesController : BaseController
    {
        private readonly IPostsService jokes;

        public JokesController(
            IPostsService jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }
    }
}
