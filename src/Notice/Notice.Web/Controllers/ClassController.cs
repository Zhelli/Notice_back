using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Notice.Web.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddClass()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult EditClass()
        {
            return View();
        }
    }
}