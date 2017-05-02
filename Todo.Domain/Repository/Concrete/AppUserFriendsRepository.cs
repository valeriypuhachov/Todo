using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Context;
using Todo.Domain.Entities;
using Todo.Domain.Repository.Abstract;

namespace Todo.Domain.Repository.Concrete
{
    public class AppUserFriendsRepository : IUserFriendsRepository
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public AppUserFriendsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        public void Add(UserFriend item)
        {
            if (item.UserFriendId.Equals(Guid.Empty))
            {
                item.UserFriendId = Guid.NewGuid();
                _context.UserFriends.Add(item);
                _context.SaveChanges();
            }
        }

        public void Edit(UserFriend item)
        {
            throw new NotSupportedException();
        }

        public UserFriend Delete(string id)
        {
            UserFriend deletedFriend = _context.UserFriends
                .FirstOrDefault(x => x.UserFriendId.ToString().Equals(id));
            if (deletedFriend != null)
            {
                _context.UserFriends.Remove(deletedFriend);
                _context.SaveChanges();
            }

            return deletedFriend;
        }

        public UserFriend FindById(string id)
        {
            return _context.UserFriends.FirstOrDefault(x => x.UserFriendId.ToString().Equals(id));
        }

        public IEnumerable<UserFriend> Get()
        {
            return _context.UserFriends;
        }

        public IEnumerable<UserFriend> GetUsersFriends(string userId)
        {
            foreach (UserFriend userFriend in _context.UserFriends)
            {
                if (userFriend.UserId.ToString() == userId)
                    yield return userFriend;
            }
        }
    }
}
