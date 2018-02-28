using Microsoft.AspNet.Identity.EntityFramework;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class AppFromBookContext : IdentityDbContext, IAppFromBookContext
    {
        public AppFromBookContext() : base("AppFromBook")
        {
        }

        public static AppFromBookContext Create()
        {
            return new AppFromBookContext();
        }
        
        public DbSet<User> User { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AnnouncementCategory> AnnouncementCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Wylacza konwencje, ktora automatycznie tworzy liczbe mnoga dla nazw tabel w bazie danych. 
            //Zamiast Announcement zostalaby utworzona tabela Announcements
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //wylacza konwencje CascadeDelete. Zostanie wlaczone za pomoca Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //uzywa sie Fluent API, aby ustalic powiazanie pomiedzy tabelami i wlaczyc CascadeDelete dla tego powiazania
            modelBuilder.Entity<Announcement>().HasRequired(x => x.User).WithMany(x => x.Announcement).HasForeignKey(x => x.UserId).WillCascadeOnDelete(true);
        }
        
    }
}