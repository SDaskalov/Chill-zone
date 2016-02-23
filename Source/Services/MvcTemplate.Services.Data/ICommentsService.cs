namespace ChillZone.Services.Data
{
    using MvcTemplate.Data.Models;

    public interface ICommentsService
    {
        Comment Add(Comment content);
    }
}
