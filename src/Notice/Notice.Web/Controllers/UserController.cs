﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notice.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
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
        public IActionResult Edit2User()
        {
            return View();
        }
        public IActionResult ProfileUser()
        {
            return View();
        }
    }
}
