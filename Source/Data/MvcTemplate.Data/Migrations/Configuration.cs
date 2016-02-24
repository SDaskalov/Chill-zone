namespace ChillZone.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ChillZone.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class Configuration : DbMigrationsConfiguration<ChillZone.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string PublicUserName = "user@user.com";
            const string PublicUserPassword = PublicUserName;
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var publicRole = new IdentityRole { Name = GlobalConstants.PublicRoleName };
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);
                roleManager.Create(publicRole);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                var publicUser = new ApplicationUser { UserName = PublicUserName, Email = PublicUserName };

                userManager.Create(user, AdministratorPassword);
                userManager.Create(publicUser, PublicUserPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
                userManager.AddToRole(publicUser.Id, GlobalConstants.PublicRoleName);
            }
        }
    }
}
