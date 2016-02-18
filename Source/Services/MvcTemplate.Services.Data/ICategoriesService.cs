namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
