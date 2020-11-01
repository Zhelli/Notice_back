using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notice.Web.ViewModels;

namespace Notice.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser(UserViewModel userModel)
        {
            
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }
    }
}