﻿using Microsoft.AspNetCore.Mvc;

namespace Jumia_MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
