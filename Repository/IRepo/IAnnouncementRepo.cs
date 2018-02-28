using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface IAnnouncementRepo
    {
        IQueryable<Announcement> GetAnnouncements();
        Announcement GetAnnouncementById(int id);
        void DeleteAnnouncement(int id);

        void SaveChanges();
        void Add(Announcement announcement);
        void UpdateAnnouncement(Announcement announcement);
    }
}
