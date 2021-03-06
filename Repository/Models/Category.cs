﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Category
    {
        public Category()
        {
            this.AnnouncementCategory = new HashSet<AnnouncementCategory>();
        }

        [Key]
        [Display(Name = "Id kategorii: ")]
        public int Id { get; set; }

        [Display(Name = "Nazwa kategorii: ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Id rodzica: ")]
        [Required]
        public int ParentId { get; set; }

        #region SEO
        [Display(Name = "Tutyl w Google: ")]
        [MaxLength(72)]
        public string MetaTitle { get; set; }

        [Display(Name = "Opis strony w Google: ")]
        [MaxLength(160)]
        public string MetaDescription { get; set; }

        [Display(Name = "Słowa kluczowe Google: ")]
        [MaxLength(160)]
        public string MetaWords { get; set; }

        [Display(Name = "Treść strony: ")]
        [MaxLength(500)]
        public string Text { get; set; }

        #endregion

        public ICollection<AnnouncementCategory> AnnouncementCategory { get; set; }

    }
}