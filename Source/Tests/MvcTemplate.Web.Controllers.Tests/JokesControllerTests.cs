/*namespace ChillZone.Web.Controllers.Tests
{
    using ChillZone.Data.Models;
    using ChillZone.Services.Data;
    using ChillZone.Web.Infrastructure.Mapping;
    using ChillZone.Web.ViewModels.Home;
    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class JokesControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(PostsController).Assembly);
            const string TestContent = "SomeContent";
            var postsServiceMock = new Mock<IPostsService>();
            postsServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new Post { SharedPhotoUrl = TestContent, Category = new PostCategory { Name = "asda" } });
            var controller = new PostsController(postsServiceMock.Object);
            controller.WithCallTo(x => x.ById("asdasasd"))
                .ShouldRenderView("ById")
                .WithModel<PostViewModel>(
                    viewModel =>
                        {
                            Assert.AreEqual(TestContent, viewModel.Content);
                        }).AndNoModelErrors();
        }
    }
}*/
