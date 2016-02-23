namespace ChillZone.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ChillZone.Data.Models;
    using ChillZone.Web.Infrastructure.Mapping;
    using MvcTemplate.Data.Models;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}
