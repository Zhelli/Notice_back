using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Notice.Web.ViewModels;
=======

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
>>>>>>> main

namespace Notice.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD

        public IActionResult AddingUser(UserViewModel userModel)
        {
            
            return View();
        }
    }
}
=======
        public IActionResult AddUser()
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
>>>>>>> main
