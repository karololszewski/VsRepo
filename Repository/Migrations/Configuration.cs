namespace Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Repository.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Models.AppFromBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repository.Models.AppFromBookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //if (System.Diagnostics.Debugger.IsAttached == false) System.Diagnostics.Debugger.Launch();
            SeedRoles(context);
            SeedUsers(context);
            SeedAnnouncement(context);
            SeedCategory(context);
            SeedAnnouncementCategory(context);
        }

        private void SeedRoles(AppFromBookContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(AppFromBookContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User() { UserName = "Admin"};
                var adminResult = manager.Create(user, "12345678");

                if (adminResult.Succeeded) manager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedAnnouncement(AppFromBookContext context)
        {
            var idUser = context.Set<User>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            for (int i = 1; i <= 10; i++)
            {
                var announcement = new Announcement()
                {
                    Id = i,
                    UserId = idUser,
                    Text = "Tresc ogloszenia nr. " + i.ToString(),
                    Title = "Tytul ogloszenia " + i.ToString(),
                    DateAdd = DateTime.Now.AddDays(-1)
                };
                context.Set<Announcement>().AddOrUpdate(announcement);
            }
            context.SaveChanges();
        }

        private void SeedCategory(AppFromBookContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var category = new Category()
                {
                    Id = i,
                    Name = "Nazwa " + i.ToString(),
                    Text = "Tresc kategorii " + i.ToString(),
                    MetaTitle = "Tytul kategorii " + i.ToString(),
                    MetaDescription = "Opis kategorii " + i.ToString(),
                    MetaWords = "Slowa klucze w kategorii" + i.ToString(),
                    ParentId = i
                };
                context.Set<Category>().AddOrUpdate(category);
            }
            context.SaveChanges();
        }

        private void SeedAnnouncementCategory(AppFromBookContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var announcementCategory = new AnnouncementCategory()
                {
                    Id = i,
                    AnnouncementId = i / 2 + 1,
                    CategoryId = i / 2 + 2
                };
                context.Set<AnnouncementCategory>().AddOrUpdate(announcementCategory);
            }
            context.SaveChanges();
        }
    }
}
