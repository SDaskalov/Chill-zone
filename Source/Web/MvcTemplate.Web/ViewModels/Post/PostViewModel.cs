namespace ChillZone.Web.ViewModels.Home
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using ChillZone.Data.Models;
    using ChillZone.Services.Web;
    using ChillZone.Web.Infrastructure.Mapping;
    using MvcTemplate.Data.Models;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string SharedUrl { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public CommentViewModel NewComment { get; set; }

        public IEnumerable<Point> Points { get; set; }

        public bool IsVideo { get; set; }

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
