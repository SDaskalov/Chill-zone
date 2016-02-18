namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
