using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Todo.WebUI.Models;
using System.Web.Mvc.Ajax;

namespace Todo.WebUI.HtmlHelpers {
    public static class PagingHelpers {
        public static HtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl) {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPage; i++) {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (pagingInfo.CurrentPage == i) {
                    tag.AddCssClass("selected btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PageLinks(this AjaxHelper ajax,
            PagingInfo pagingInfo, string actionName,
            string controllerName, AjaxOptions options) {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPage; i++) {
                var htmlAttributes =
                    pagingInfo.CurrentPage == i ?
                    new { @class = "btn btn-default selected btn-primary" } :
                    new { @class = "btn btn-default" };
                var link = ajax.ActionLink(i.ToString(), actionName, controllerName, new { page = i}, options, htmlAttributes);
                result.Append(link);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}