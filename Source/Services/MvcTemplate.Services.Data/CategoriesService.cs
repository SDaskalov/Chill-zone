namespace ChillZone.Services.Data
{
    using System.Linq;

    using ChillZone.Data.Common;
    using ChillZone.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<PostCategory> categories;

        public CategoriesService(IDbRepository<PostCategory> categories)
        {
            this.categories = categories;
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

        public IQueryable<PostCategory> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
