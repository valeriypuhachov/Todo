using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Abstract;
using Todo.Domain.Models;

namespace Todo.Domain.Concrete
{
    class AppUserRepository : IUserRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void SaveChanges(ApplicationUser _user)
        {
            ApplicationUser user = context.Users.FirstOrDefault(u => u.Id.Equals(_user.Id));
            user.UserName = _user.UserName;
            user.Patronomic = _user.Patronomic;
            user.PhoneNumber = _user.PhoneNumber;
            user.Surname = _user.Surname;
            user.Photo = _user.Photo;
            user.Comment = _user.Comment;
            //user.
        }

    
    }
}
