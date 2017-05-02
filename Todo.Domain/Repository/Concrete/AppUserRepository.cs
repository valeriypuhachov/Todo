using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using Todo.Domain.Entities;
using Todo.Domain.Repository.Abstract;

namespace Todo.Domain.Repository.Concrete {
    public class AppUserRepository : IUserRepository {

        private readonly IdentityDbContext<ApplicationUser> _context;
        private bool isDisposed = false;

        public AppUserRepository(IdentityDbContext<ApplicationUser> context) {
            _context = context;
        }

        public void Add(ApplicationUser item) {
            if (item.Id.Equals(default(Guid))) {
                _context.Users.Add(item);
            } else {
                ApplicationUser dbEntry = _context.Users.FirstOrDefault(x => x.Id.Equals(item.Id));
                if (dbEntry != null) {
                    dbEntry.UserName = item.UserName;
                    dbEntry.Surname = item.Surname;
                }
            }
        }

        public ApplicationUser Delete(string id) {
            ApplicationUser user = _context.Users.FirstOrDefault(x => x.Id == id.ToString());
            if (user != null) {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }

        public void Dispose() {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing) {
            if (!this.isDisposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.isDisposed = true;
        }

        public void Edit(ApplicationUser item) {
            Edit(item);
        }

        public ApplicationUser FindById(string id) => _context.Users.FirstOrDefault(m => m.Id == id.ToString());

        public IEnumerable<ApplicationUser> Get() => _context.Users;
    }
}
