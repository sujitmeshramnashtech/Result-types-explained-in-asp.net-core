using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ActionResultDemo.Controllers
{
    // The ResultDemoController demonstrates various ActionResults available in ASP.NET Core MVC.
    public class ResultDemoController : Controller
    {
        // 1. ViewResult: Renders a view (HTML page) to the client.
        // This method returns a view called "HomeView" located in Views/ResultDemo folder.
        public IActionResult Home()
        {
            return View("HomeView");
        }

        // 2. JsonResult: Returns JSON-formatted data, commonly used in APIs.
        // This method returns user data in JSON format.
        public JsonResult GetUserInfo()
        {
            var user = new { Username = "Alice", Age = 25 };
            return Json(user);
        }

        // 3. ContentResult: Returns plain text or other types of content.
        // This method returns a simple text message.
        public ContentResult ShowMessage()
        {
            return Content("This is a simple content result.");
        }

        // 4. FileResult: Returns a file to the client.
        // This method reads a file and returns it as a downloadable file.
        public FileResult DownloadDocument()
        {
            // Replace with the path to your file.
            byte[] fileBytes = System.IO.File.ReadAllBytes("files/sample.docx");
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "sample.docx");
        }

        // 5. RedirectResult: Redirects the client to a specified URL.
        // This method redirects to an external website.
        public RedirectResult RedirectToExternalSite()
        {
            return Redirect("https://www.google.com");
        }

        // 6. RedirectToActionResult: Redirects the client to a specific action method.
        // This method redirects to the "Dashboard" action in the "User" controller.
        public RedirectToActionResult GoToDashboard()
        {
            return RedirectToAction("Dashboard", "User");
        }

        // 7. RedirectToRouteResult: Redirects the client to a specific route.
        // This method redirects to a route defined with a controller and action.
        public RedirectToRouteResult RedirectToCustomRoute()
        {
            return RedirectToRoute(new { controller = "Profile", action = "Details", id = 5 });
        }

        // 8. StatusCodeResult: Returns a specific HTTP status code.
        // This method returns a 404 Not Found status code.
        public StatusCodeResult ReturnNotFound()
        {
            return StatusCode(404); // Not Found
        }

        // 9. EmptyResult: Does not return any content.
        // This method performs some operations and returns nothing.
        public EmptyResult ExecuteSilently()
        {
            // Perform some operations here if needed.
            return new EmptyResult();
        }

        // 10. PartialViewResult: Renders a partial view.
        // This method returns a partial view called "_PartialDetails".
        public PartialViewResult LoadPartial()
        {
            return PartialView("_PartialDetails");
        }

        // 11. ObjectResult: Returns an object as the response, typically used in APIs.
        // This method returns product data as an object result with status code 200.
        public ObjectResult FetchData()
        {
            var product = new { Id = 1, Name = "Laptop", Price = 999.99 };
            return new ObjectResult(product) { StatusCode = 200 };
        }
    }
}
