﻿namespace ChillZone.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ChillZone.Data.Common.Models;

    public class PostCategory : BaseModel<int>
    {
        private ICollection<Post> posts;

        public PostCategory()
        {
            this.posts = new HashSet<Post>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        [ForeignKey("Name")]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
