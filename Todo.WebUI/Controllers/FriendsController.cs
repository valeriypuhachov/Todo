using System;
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
            List<UserViewModel> userFriendViewModels = new List<UserViewModel>();
            foreach (UserFriend friend in friends)
            {
                ApplicationUser usersFriend = userRepository.FindById(friend.FriendId.ToString());
                userFriendViewModels.Add(new UserViewModel
                {
                    FriendId = friend.UserFriendId.ToString(),
                    Name = usersFriend.FirstName,
                    Surname = usersFriend.Surname,
                });
            }
            return View(userFriendViewModels);
        }

        public async Task<ActionResult> Users()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            IEnumerable<UserFriend> friends = _factory.UserFriendsRepository.GetUsersFriends(user.Id).ToList();

            IUserRepository userRepository = _factory.UserRepository;

            List<ApplicationUser> users = userRepository.Get().ToList();
            List<UserViewModel> resultUserSet = new List<UserViewModel>();
            foreach (ApplicationUser appUser in users)
            {
                bool isValid = true;
                foreach (UserFriend friend in friends)
                {
                    if (appUser.Id == friend.FriendId.ToString())
                        isValid = false;
                }

                if (isValid && appUser.Id != user.Id)
                    resultUserSet.Add(new UserViewModel
                    {
                        Name = appUser.FirstName,
                        Surname = appUser.Surname,
                        FriendId = appUser.Id
                    });
            }

            return View(resultUserSet);
        }

        [HttpPost]
        public ActionResult RemoveFriend(string friendId)
        {
            _userFriendsRepository.Delete(friendId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddFriend(string friendId)
        {
            _userFriendsRepository.Add(new UserFriend
            {
                FriendId = Guid.Parse(friendId),
                UserId = Guid.Parse(User.Identity.GetUserId())
            });
            return RedirectToAction("Users");
        }
    }
}