using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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

        public string Comment { get; set; }
        public string Patronomic { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public virtual List<UserTask> Tasks { get; set; }

        public ApplicationUser() {
            this.Tasks = new List<UserTask>();
        }
    }
}
