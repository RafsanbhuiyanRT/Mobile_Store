﻿using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace EcommerceApp.Controllers
{
    public class AccountController(AppDbContext db, UserManager<ApplicationUser> userManager,
      RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager,
      IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : Controller
    {

        private AppDbContext _db => db;
        private UserManager<ApplicationUser> _userManager => userManager;
        private RoleManager<IdentityRole> _roleManager => roleManager;
        private SignInManager<ApplicationUser> _signInManager => signInManager;
        private IWebHostEnvironment _webHostEnvironment => webHostEnvironment;
        private IConfiguration _configuration => configuration;


        public IActionResult LoginIndex()
        {
            return View();
        }

        public IActionResult SignUpIndex()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> SignUp(int id, string email, string phone, string userName, string password, string confirmPassword, string address, bool condition)
        {
            string message = "";
            if (id == 0)
            {
                if ((_db.Logins.FirstOrDefault(x => x.UserName == userName) is null))
                {
                    var signup = new Signup
                    {
                        Email = email,
                        Phone = phone,
                        Username = userName,
                        Password = password,
                        ConfirmPassword = confirmPassword,
                        Address = address,
                        Condition = condition
                    };
                    _db.Signups.Add(signup);
                    _db.SaveChanges();

                    var user = new ApplicationUser
                    {
                        UserName = userName,
                        Email = email,
                        SecurityStamp = Guid.NewGuid().ToString("D") + 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        Name = userName,
                        RegistationDate = DateTime.Now,
                        UserType = "Customar",
                        EntityId = signup.Id
                    };
                    var result = await _userManager.CreateAsync(user, "1210");
                    await _userManager.AddToRoleAsync(user, "Customar");
                    message = "sussessfully save";
                }
                else
                {
                    message = "Customar already exist";
                }
            }  
            return Json(message);
        }

        //public async Task<JsonResult> Update(int id, string email, string phone, string userName, string password, string confirmPassword, bool condition)
        //{
        //    var data = _db.l
        //    return null;
        //}

    }
}
