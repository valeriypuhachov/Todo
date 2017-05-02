using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repository.Abstract
{
    public interface IUserFriendsRepository : IRepository<UserFriend>
    {
        IEnumerable<UserFriend> GetUsersFriends(string userId);
    }
}
