﻿namespace Repository.Models
{
    public class AnnouncementCategory
    {
        public AnnouncementCategory()
        {

        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AnnouncementId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Announcement Announcement { get; set; }

    }
}