using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
