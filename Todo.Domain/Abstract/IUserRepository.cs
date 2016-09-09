using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Domain.Abstract
{
    public interface IUserRepository
    {
        void SaveChanges(ApplicationUser user);

    }

}
