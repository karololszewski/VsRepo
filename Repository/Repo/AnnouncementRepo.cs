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

        public IQueryable<Announcement> GetAnnouncements()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Announcements.AsNoTracking();
        }
    }
}