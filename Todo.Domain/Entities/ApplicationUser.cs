using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
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

        public ApplicationUser() {
            this.Tasks = new List<UserTask>();
        }
    }
}
