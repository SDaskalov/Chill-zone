namespace MvcTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using ChillZone.Data.Common.Models;
    using ChillZone.Data.Models;

    public class Point : BaseModel<int>
    {
        public int Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
