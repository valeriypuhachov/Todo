using Todo.Domain.Repository.Abstract;
using Todo.Domain.Context;

namespace Todo.Domain.Repository.Concrete {
    public class EFRepositoryFactory : IRepositoryFactory {

        private readonly ApplicationDbContext _dbContext;

        public EFRepositoryFactory() {
            _dbContext = new ApplicationDbContext();
        }

        public IUserRepository UserRepository => new AppUserRepository(_dbContext);

        public IUserTaskRepository UserTaskRepository => new AppTaskRepository(_dbContext);
        public IUserFriendsRepository UserFriendsRepository => new AppUserFriendsRepository(_dbContext);
        public ITaskParticipantRepository TaskParticipantrepository => new TaskParticipantRepository(_dbContext);
    }
}
