﻿namespace ChillZone.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using MvcTemplate.Data.Models;

    public class Post : BaseModel<int>
    {
        private ICollection<Point> points;
        private ICollection<Comment> comments;

        public Post()
        {
            this.points = new HashSet<Point>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory Category { get; set; }

        [Required]
        public string SharedUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsVideo { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Point> Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
