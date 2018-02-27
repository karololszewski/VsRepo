using Repository.IRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
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

        public bool DeleteAnnouncement(int id)
        {
            Announcement announcement = GetAnnouncementById(id);
            _db.Announcements.Remove(announcement);
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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
    }
}