﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Repository.Abstract {
    public interface IRepositoryFactory {
        IUserTaskRepository UserTaskRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
