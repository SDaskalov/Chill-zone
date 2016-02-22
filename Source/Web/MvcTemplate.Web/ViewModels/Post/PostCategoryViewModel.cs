namespace ChillZone.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ChillZone.Data.Models;
    using ChillZone.Web.Infrastructure.Mapping;

    public class PostCategoryViewModel : IMapFrom<PostCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PostCategory, PostCategoryViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Posts));
        }
    }
}
