using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpPost]
        [Authorize]
        public IActionResult Details(int id)
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
            return RedirectToAction("Index", "Home");
        }
    }
}
