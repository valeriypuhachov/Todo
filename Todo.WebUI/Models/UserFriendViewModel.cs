using System.ComponentModel.DataAnnotations;

namespace Todo.WebUI.Models
{
    public class UserFriendViewModel
    {
        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }
        public string FriendId { get; set; }
    }
}