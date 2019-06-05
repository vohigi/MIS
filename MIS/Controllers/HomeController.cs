using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MIS.Models;
using Microsoft.AspNetCore.Authorization;

namespace MIS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult AdminPage() => View();
        [Authorize(Roles = "owner, admin")]
        public IActionResult OwnerPage() => View();
    }
}
