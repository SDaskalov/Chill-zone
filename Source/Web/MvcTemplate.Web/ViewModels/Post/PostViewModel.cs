namespace ChillZone.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using ChillZone.Data.Models;
    using ChillZone.Services.Web;
    using ChillZone.Web.Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string SharedPhotoUrl { get; set; }

        public byte[] UploadPhoto { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Post/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
