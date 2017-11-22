using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface IAppFromBookContext
    {
        DbSet<User> User { get; set; }
        DbSet<Announcement> Announcements { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<AnnouncementCategory> AnnouncementCategories { get; set; }

        int SaveChanges();
        Database Database { get; }
    }
}
