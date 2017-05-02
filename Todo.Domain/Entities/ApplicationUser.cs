using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Todo.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //public ApplicationUser()
        //{
        //    Tasks = new List<UserTask>();
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public override string UserName {
            get {
                return base.UserName;
            }

            set {
                base.UserName = value;
            }
        }

        [Phone]
        public override string PhoneNumber {
            get {
                return base.PhoneNumber;
            }

            set {
                base.PhoneNumber = value;
            }
        }

        [EmailAddress]
        public override string Email {
            get {
                return base.Email;
            }

            set {
                base.Email = value;
            }
        }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public string Patronomic { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        public byte[] Photo { get; set; }

        public string ImageMimeType { get; set; }

        public virtual List<UserTask> Tasks { get; set; }

        public virtual List<UserFriend> Friends { get; set; }
    }
}
