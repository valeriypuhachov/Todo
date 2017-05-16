namespace Todo.Domain.Repository.Abstract {
    public interface IRepositoryFactory {
        IUserTaskRepository UserTaskRepository { get; }
        IUserRepository UserRepository { get; }
        IUserFriendsRepository UserFriendsRepository { get; }
        ITaskParticipantRepository TaskParticipantrepository { get; }
    }
}
