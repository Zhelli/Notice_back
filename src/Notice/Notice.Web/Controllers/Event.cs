﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notice.Web.Controllers
{
    public class Event : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddEvent()
        {
            return View();
        }
        public IActionResult EditEvent()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}