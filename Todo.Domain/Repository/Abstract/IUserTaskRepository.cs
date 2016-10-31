using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Models;
using Todo.Domain.Repository.Abstract;

namespace Todo.Domain.Repository.Abstract {
    public interface IUserTaskRepository : IRepository<UserTask> {
        //IEnumerable<UserTask> UserTasks { get; }
        //void SaveUserTask(UserTask userTask);
        //UserTask DeleteUserTask(Guid taskId);
    }
}
