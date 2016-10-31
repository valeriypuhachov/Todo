using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Globalization;

namespace Todo.WebUI.Controllers {
    [AllowAnonymous]
    public class HomeController : Controller {
        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);

            if (Session["CurrentCulture"] != null) {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
            }
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Описание";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Свяжитесь с нами";

            return View();
        }

        public ActionResult ChangeCulture(string appCulture, string returnUrl) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(appCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(appCulture);

            Session["CurrentCulture"] = appCulture;
            return Redirect(returnUrl);
        }
    }
}