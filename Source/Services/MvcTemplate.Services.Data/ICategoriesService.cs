namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<PostCategory> GetAll();

        PostCategory GetByName(string name);

        PostCategory EnsureCategory(string name);

        PostCategory Create(string name);
    }
}
