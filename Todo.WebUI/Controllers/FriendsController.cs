using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Todo.Domain.Entities;
using Todo.Domain.Identity;
using Todo.Domain.Repository.Abstract;
using Todo.WebUI.Models;

namespace Todo.WebUI.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IRepositoryFactory _factory;
        private readonly IUserFriendsRepository _userFriendsRepository;

        public ApplicationUserManager UserManager
            => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session["CurrentCulture"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
            }

        }

        public FriendsController(IRepositoryFactory factory)
        {
            _factory = factory;
            _userFriendsRepository = _factory.UserFriendsRepository;
        }

        // GET: Friends
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<UserFriend> friends = _factory.UserFriendsRepository.GetUsersFriends(user.Id).ToList();

            IUserRepository userRepository = _factory.UserRepository;
            List<UserFriendViewModel> userFriendViewModels = new List<UserFriendViewModel>();
            foreach (UserFriend friend in friends)
            {
                ApplicationUser usersFriend = userRepository.FindById(friend.FriendId.ToString());
                userFriendViewModels.Add(new UserFriendViewModel
                {
                    FriendId = friend.UserFriendId.ToString(),
                    Name = usersFriend.UserName,
                    Surname = usersFriend.Surname,
                });
            }
            return View(userFriendViewModels);
        }

        public async Task<ActionResult> RemoveFriend(UserFriendViewModel userFriendViewModel)
        {
            _userFriendsRepository.Delete(userFriendViewModel.FriendId);
            return RedirectToAction("Index");
        }
    }
}