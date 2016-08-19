using System.Web.Mvc;
using UaaSandVSDemo.Core.Models;
using Umbraco.Web.Mvc;

namespace UaaSandVSDemo.Core.Controllers
{
    public class CommentController : SurfaceController
    {
        public ActionResult Submit(CommentModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var contentService = Services.ContentService;
            var newComment = contentService.CreateContent(model.Name, CurrentPage.Id, "commentForm");
            newComment.SetValue("firstName", model.Name);
            newComment.SetValue("email", model.Email);
            newComment.SetValue("message", model.Comment);

            Services.ContentService.SaveAndPublishWithStatus(newComment);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}