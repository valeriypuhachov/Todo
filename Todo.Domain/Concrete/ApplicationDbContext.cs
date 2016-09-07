using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Domain.Models;
using System.Data.Entity;

namespace Todo.Domain.Concrete {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() : base("TodoConnection") {

        }

        static ApplicationDbContext() {
            Database.SetInitializer<ApplicationDbContext>(new IdentityDbInit());
        }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

        public DbSet<UserTask> UserTasks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Tasks)
        //        .WithRequired(x => x.User).HasForeignKey(x => x.UserID);
        //}
    }

    internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApplicationDbContext> {
        protected override void Seed(ApplicationDbContext context) {
            base.Seed(context);
        }
    }
}