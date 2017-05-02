using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Todo.WebUI.Models;
using Microsoft.AspNet.Identity;
using Todo.Domain.Identity;
using System.Web.Routing;
using System.Threading;
using System.Globalization;
using Todo.Domain.Entities;

namespace Todo.WebUI.Controllers {
    [Authorize]
    public class ProfileController : Controller {
        private ApplicationUserManager _userManager;
        private int _itemPerPage = 2;

        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);

            if (Session["CurrentCulture"] != null) {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
            }
        }

        // GET: User
        public ActionResult Index() {
            return View();
        }

        public async Task<ActionResult> Show(int page = 1) {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            DisplayProfileViewModel model = new DisplayProfileViewModel {
                Id = user.Id,
                Name = user.FirstName,
                Surname = user.Surname,
                Patronomic = user.Patronomic,
                Description = user.Comment,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo
            };
            return View(model);
        }

        public async Task<ActionResult> Edit() {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            EditViewModel model = new EditViewModel {
                Id = user.Id,
                Patronomic = user.Patronomic,
                Photo = user.Photo,
                Surname = user.Surname,
                Name = user.FirstName,
                Description = user.Comment,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel model, HttpPostedFileBase image = null) {
            if (ModelState.IsValid) {
                IdentityResult result = null;
                ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.FirstName = model.Name;
                user.Surname = model.Surname;
                user.Patronomic = model.Patronomic;
                user.PhoneNumber = model.PhoneNumber;
                user.Comment = model.Description;
                if (image != null) {
                    user.Photo = new byte[image.ContentLength];
                    await image.InputStream.ReadAsync(user.Photo, 0, image.ContentLength);
                    user.ImageMimeType = image.ContentType;
                }
                result = await UserManager.UpdateAsync(user);
                // TODO: Add redirecting to error message.
            }
            return RedirectToAction("Index", "Home");
        }

        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        public async Task<FileContentResult> GetPhoto(string id) {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            return File(user?.Photo, user.ImageMimeType);
        }
    }
}