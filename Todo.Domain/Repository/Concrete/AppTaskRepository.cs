using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Context;
using Todo.Domain.Models;
using Todo.Domain.Repository.Abstract;

namespace Todo.Domain.Repository.Concrete {
    public class AppTaskRepository : IUserTaskRepository {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public AppTaskRepository(ApplicationDbContext context) {
            _context = context;
        }

        public void Add(UserTask item) {
            Edit(item);
        }

        public UserTask Delete(string id) {
            UserTask deletedTask = _context.UserTasks
                .FirstOrDefault(x => x.TaskId.ToString().Equals(id));
            if (deletedTask != null) {
                _context.UserTasks.Remove(deletedTask);
                _context.SaveChanges();
            }
            return deletedTask;
        }

        public void Edit(UserTask item) {
            if (item.TaskId.Equals(Guid.Empty)) {
                item.TaskId = Guid.NewGuid();
                _context.UserTasks.Add(item);

            } else {
                UserTask dbEntry = _context.UserTasks.FirstOrDefault(x => x.TaskId.ToString().Equals(item.TaskId));
                if (dbEntry != null) {
                    dbEntry.TaskName = item.TaskName;
                    dbEntry.TaskDescription = item.TaskDescription;
                    dbEntry.TaskState = item.TaskState;
                    dbEntry.Time = item.Time;
                    dbEntry.Latitude = item.Latitude;
                    dbEntry.Longitude = item.Longitude;

                }
            }
            _context.SaveChanges();
        }

        public UserTask FindById(string id) {
            return _context.UserTasks.FirstOrDefault(x => x.TaskId.ToString().Equals(id));
        }

        public void Dispose() {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IEnumerable<UserTask> UserTasks(string userId) {
            return _context.UserTasks.Where(x => x.UserId == userId).Select(x => x);
        }

        public IEnumerable<UserTask> Get() => _context.UserTasks;
    }
}
