using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Abstract;
using Todo.Domain.Models;

namespace Todo.Domain.Concrete
{
    class AppTaskRepository : IUserTaskRepository
    {
        private string _UserId;

        public AppTaskRepository(string UserId)
        {
            _UserId = UserId;
        }
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<UserTask> UserTasks
        {
            get
            {
                var rezult = from userTask in context.UserTasks
                             where (userTask.UserId.Equals(_UserId))
                             select userTask;

                return rezult;
            }
        }
      
        public UserTask DeleteUserTask(Guid taskId)
        {
            UserTask deletedTask = context.UserTasks
                .FirstOrDefault(t => t.TaskId.Equals(taskId));
            if(deletedTask != null)
            {
                context.UserTasks.Remove(deletedTask);
                context.SaveChanges();
            }
            return deletedTask;

        }

        public void SaveUserTask(UserTask task)
        {
            if (task.TaskId.Equals(default(Guid)))
            {
                context.UserTasks.Add(task);
                
            }
            else
            {
                UserTask dbEntry = context.UserTasks.FirstOrDefault(t => t.TaskId.Equals(task.TaskId));
                if(dbEntry != null)
                {
                    dbEntry.TaskName = task.TaskName;
                    dbEntry.TaskDescription = task.TaskDescription;
                    dbEntry.TaskState = task.TaskState;
                    dbEntry.Time = task.Time;
                    dbEntry.Location = task.Location;
                    
                }
            }
            context.SaveChanges();
        }
    }
}
