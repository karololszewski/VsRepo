using Repository.IRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Repository.Repo
{
    public class AnnouncementRepo : IAnnouncementRepo
    {
        private readonly IAppFromBookContext _db;

        public AnnouncementRepo(IAppFromBookContext db)
        {
            _db = db;
        }

        public void Add(Announcement announcement)
        {
            _db.Announcements.Add(announcement);
        }

        public void DeleteAnnouncement(int id)
        {
            DeleteLinkedAnnouncementCategories(id);
            Announcement announcement = GetAnnouncementById(id);
            _db.Announcements.Remove(announcement);
        }

        public Announcement GetAnnouncementById(int id)
        {
            return _db.Announcements.Find(id);
        }

        public IQueryable<Announcement> GetAnnouncements()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Announcements.AsNoTracking();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            _db.Entry(announcement).State = EntityState.Modified;
        }

        private void DeleteLinkedAnnouncementCategories(int idAnnouncement)
        {
            var list = _db.AnnouncementCategories.Where(o => o.AnnouncementId == idAnnouncement);
            foreach (var item in list)
            {
                _db.AnnouncementCategories.Remove(item);
            }
        }

    }
}