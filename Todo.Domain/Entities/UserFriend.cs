using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Entities
{
    public class UserFriend
    {
        [Key]
        public Guid UserFriendId { get; set; }

        public Guid UserId { get; set; }

        public Guid FriendId { get; set; }
    }
}
