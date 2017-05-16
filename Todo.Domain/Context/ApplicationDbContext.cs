using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Todo.Domain.Entities;

namespace Todo.Domain.Context {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() : base("TodoConnection") {

        }

        static ApplicationDbContext() {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<UserFriend> UserFriends { get; set; }

        public DbSet<TaskParticipant> TaskParticipants { get; set; }
    }

    internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApplicationDbContext> {
        protected override void Seed(ApplicationDbContext context) {
            base.Seed(context);
        }
    }
}