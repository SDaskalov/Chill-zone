namespace ChillZone.Data.Models
{
    using System.Collections.Generic;

    using ChillZone.Data.Common.Models;

    public class PostCategory : BaseModel<int>
    {
        private ICollection<Post> posts;

        public PostCategory()
        {
            this.posts = new HashSet<Post>();
        }

        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
