using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Controllers
{
    public class PagesController : Controller
    {

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Viewer()
        {
            return View();
        }


        
    }
}
