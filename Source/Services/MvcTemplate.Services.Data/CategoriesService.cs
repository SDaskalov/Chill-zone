namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Common;
    using ChillZone.Data.Models;
    using Web;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<PostCategory> categories;
        private readonly IIdentifierProvider identifierProvider;

        public CategoriesService(IDbRepository<PostCategory> categories, IIdentifierProvider identifierProvider)
        {
            this.categories = categories;
            this.identifierProvider = identifierProvider;
        }

        public PostCategory EnsureCategory(string name)
        {
            var category = this.categories.All().FirstOrDefault(x => x.Name == name);
            if (category != null)
            {
                return category;
            }

            category = new PostCategory { Name = name };
            this.categories.Add(category);
            this.categories.Save();
            return category;
        }

        public PostCategory Create(string name)
        {
            var category = new PostCategory() { Name = name };

            this.categories.Add(category);

            this.categories.Save();

            return category;
        }

        public PostCategory GetByName(string name)
        {
            return this.categories.All().Where(x => x.IsDeleted == false).First(x => x.Name == name);
        }

        public IQueryable<PostCategory> GetAll()
        {
            return this.categories.All().Where(x => x.IsDeleted == false).OrderBy(x => x.Name);
        }
    }
}
