namespace ChillZone.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Post : BaseModel<int>
    {
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory Category { get; set; }

        public string SharedPhotoUrl { get; set; }

        public byte[] UploadPhoto { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual string UserId { get; set; }
    }
}
