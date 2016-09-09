using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Domain.Abstract
{
    public interface IUserTaskRepository
    {
        IEnumerable<UserTask> UserTasks { get; }
        void SaveUserTask(UserTask userTask);
        UserTask DeleteUserTask(Guid taskId);

    }
}
