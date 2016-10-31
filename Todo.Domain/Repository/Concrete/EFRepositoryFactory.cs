using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Repository.Abstract;
using Todo.Domain.Context;
using Todo.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Todo.Domain.Repository.Concrete {
    public class EFRepositoryFactory : IRepositoryFactory {

        private ApplicationDbContext _dbContext;

        public EFRepositoryFactory() {
            _dbContext = new ApplicationDbContext();
        }

        public IUserRepository UserRepository {
            get {
                return new AppUserRepository(_dbContext);
            }
        }

        public IUserTaskRepository UserTaskRepository {
            get {
                return new AppTaskRepository(_dbContext);
            }
        }
    }
}
