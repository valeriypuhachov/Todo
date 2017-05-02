using Todo.Domain.Entities;

namespace Todo.Domain.Repository.Abstract {
    public interface IUserTaskRepository : IRepository<UserTask> {
        //IEnumerable<UserTask> UserTasks { get; }
        //void SaveUserTask(UserTask userTask);
        //UserTask DeleteUserTask(Guid taskId);
    }
}
