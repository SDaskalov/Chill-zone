namespace ChillZone.Web.ViewModels.Home
{
    using ChillZone.Data.Models;
    using ChillZone.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
