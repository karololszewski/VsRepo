using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Announcement
    {
        public Announcement()
        {
            this.AnnouncementCategory = new HashSet<AnnouncementCategory>();
        }
        
        [Display(Name = "Id: ")]
        public int Id { get; set; }

        [Display(Name = "Tresc ogloszenia: ")]
        [MaxLength(500)]
        public string Text { get; set; }

        [Display(Name = "Tytul ogloszenia: ")]
        [MaxLength(72)]
        public string Title { get; set; }

        [Display(Name = "Data dodania: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdd { get; set; }
        
        public string UserId { get; set; }

        public virtual ICollection<AnnouncementCategory> AnnouncementCategory { get; set; }

        public virtual User User { get; set; }

    }
}