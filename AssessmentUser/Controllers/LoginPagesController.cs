using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentUser.Context;
using AssessmentUser.Models;



namespace AssessmentUser.Controllers
{
    public class LoginPagesController : Controller
    {
        private readonly DContext _context;

        public static bool IsLoggedIn = false;

        public LoginPagesController(DContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]



        public IActionResult Login(LoginPage model)
        {



            ViewBag.Value = model.Username.ToString();
            ViewBag.Password = model.Password.ToString();
            string name = ViewBag.Value;



            User user = _context.Users.FirstOrDefault(x => x.Username == name);



            if (model.Username == name && model.Password == user.Password)
            {
                ViewBag.Role = user.Role;
                IsLoggedIn = true;
                ViewBag.IsLoggedIn = IsLoggedIn;
             
                if (user.Role == UserRole.Admin)
                    return RedirectToAction("", "Users");
            
                else if (user.Role == UserRole.Employee)
                    return RedirectToAction("", "Batches");
                else return RedirectToAction("Create", "Courses"); //re
            }
            else
            {



                ModelState.AddModelError("", "Invalid username or password");
            }





            return View(model);
        }
    }
}