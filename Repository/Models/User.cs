using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Announcement = new HashSet<Announcement>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Announcement> Announcement { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        #region full name
        
        [NotMapped]
        [Display(Name = "Mr/Ms: ")]
        public string FullName
        {
            get { return FirstName + ' ' + LastName; }
        }

        #endregion
    }
}