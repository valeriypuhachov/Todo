using System;
using System.Collections.Generic;
using System.Linq;

using Todo.Domain.Context;
using Todo.Domain.Entities;
using Todo.Domain.Repository.Abstract;

namespace Todo.Domain.Repository.Concrete
{
    public class TaskParticipantRepository : ITaskParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public TaskParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(TaskParticipant item)
        {
            if (item.TaskParticipantId.Equals(default(Guid)))
            {
                _context.TaskParticipants.Add(item);
            }
            else
            {
                TaskParticipant dbEntry = _context.TaskParticipants.FirstOrDefault(x => x.TaskParticipantId.Equals(item.TaskParticipantId));
                if (dbEntry != null)
                {
                    dbEntry.UserTask = item.UserTask;
                    dbEntry.ParticipantId = item.ParticipantId;
                    dbEntry.TaskId = item.TaskId;
                    dbEntry.User = item.User;
                }
            }
        }

        public TaskParticipant Delete(string id)
        {
            TaskParticipant user = _context.TaskParticipants.FirstOrDefault(x => x.TaskParticipantId.ToString() == id);
            if (user != null)
            {
                _context.TaskParticipants.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Edit(TaskParticipant item)
        {
            Edit(item);
        }

        public TaskParticipant FindById(string id)
        {
            return _context.TaskParticipants.FirstOrDefault(x => x.TaskParticipantId.ToString() == id);
        }

        public IEnumerable<TaskParticipant> Get() => _context.TaskParticipants;
    }
}
