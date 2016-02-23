namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ChillZone.Data.Common;
    using ChillZone.Services.Data;
    using MvcTemplate.Data.Models;

  public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

    public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment Add(Comment content)
        {
            this.comments.Add(content);

            this.comments.Save();

            return content;
        }
    }
}
