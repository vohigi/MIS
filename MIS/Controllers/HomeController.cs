using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MIS.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
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
        public IActionResult OwnerPage()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = _userManager.GetUserId(currentUser);
            var user = _context.Users.Include(x => x.Msp).Include(x => x.Declarations).FirstOrDefault(x => x.Id == userID);

            var mspId = user.MspId;
            if (user == null)
            {
                return Content("error");
            }
            OwnerPageViewModel model = new OwnerPageViewModel()
            {
                Owner = user,
                UserList = _context.Users.ToList()

            };
            // var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var User = await _context.Users.SingleOrDefault()
            // if(user.)

            return View(model);
        }

        public async Task<IActionResult> CreateMsp(Msps msp)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = _userManager.GetUserId(currentUser);
            var user = _context.Users.FirstOrDefault(x => x.Id == userID);
            Msps msp1 = msp;
            msp1.User.Add(user);
            await _context.Msps.AddAsync(msp);
            await _context.SaveChangesAsync();

            return RedirectToAction("OwnerPage");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("OwnerPage");
        }

        public async Task<IActionResult> CreateDoctor(OwnerPageViewModel model)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = _userManager.GetUserId(currentUser);
            var user = _context.Users.FirstOrDefault(x => x.Id == userID);
            var mspID = user.MspId;

            User newUser = new User();

            newUser.Email = model.Email;
            newUser.FirstName = model.FirstName;
            newUser.MiddleName = model.MiddleName;
            newUser.LastName = model.LastName;
            newUser.TaxId = model.TaxId;
            newUser.Gender = model.Gender;
            newUser.BirthDate = model.BirthDate;
            newUser.UserName = model.Email;
            newUser.PhoneNumber = model.PhoneNumber;
            newUser.MspId = mspID;
            RegisterViewModel model1 = new RegisterViewModel()
            {
                Password = "Aa123456"
            };
            var result = await _userManager.CreateAsync(newUser, model1.Password);
            if (result.Succeeded)
            {
                // установка куки
                var res = await _userManager.AddToRoleAsync(newUser, "doctor");

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("OwnerPage");
        }
    }
}
