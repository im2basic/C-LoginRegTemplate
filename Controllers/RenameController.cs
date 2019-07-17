using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginReg.Controllers
{
    [Route("template")]
                //Change this controller to new name
    public class RenameController : Controller
    {
        private HomeContext dbContext;
                //Change this controller to new name
        public RenameController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            User userInDb = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            ViewBag.User = userInDb;
            return View("Index");
        
        }
    }
}