using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

    public class ExternalAuthenticationController : Controller
    {
        public IActionResult CallBack()
        {
            //caputure the user object
            return RedirectToAction("Index", "Products");
        }

        public IActionResult SignOut()
        {
            var callbackUrl = Url.Page("/", pageHandler: null, values: null, protocol: Request.Scheme);
            return SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme
            );
        }
    }
}
