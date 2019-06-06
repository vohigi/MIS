using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MIS.Models;
using MIS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Globalization;

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



        [Authorize(Roles = "owner")]
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
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult AdminPage() => View();
        [Authorize(Roles = "user")]
        public async Task<IActionResult> ChooseDoctor()
        {
            var _e = await _userManager.GetUsersInRoleAsync("doctor");
            var selected = _context.Users.Include(x => x.Msp).Where(u => _e.Contains(u));
            //.Include(x => x.Msp).ToListAsync();
            return View(selected);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDeclaration(string Id)
        {
            var doctor = _context.Users.Include(x => x.Msp).FirstOrDefault(x => x.Id == Id);
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDeclaration(Declarations model)
        {
            Declarations declaration = model;
            var doctor = _context.Users.Include(x => x.Msp).FirstOrDefault(x => x.Id == model.EmployeeId);
            declaration.Employee = doctor;
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = _userManager.GetUserId(currentUser);
            var user = _context.Users.FirstOrDefault(x => x.Id == userID);
            declaration.User = user;
            declaration.Phone = user.PhoneNumber;
            declaration.Email = user.Email;
            await _context.Declarations.AddAsync(declaration);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "user")]
        public async Task<IActionResult> Appointment(AppointmentPageViewModel model)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userID = _userManager.GetUserId(currentUser);
            var user = _context.Users.Include(x => x.Declarations)
            .Include(x => x.Declarations.Employee)
            .Include(x => x.Msp)
            .FirstOrDefault(x => x.Id == userID);

            model.User = user;


            DateTime dt = DateTime.Now;
            DateTime dateDefault = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            DateTime[] dates = new DateTime[]{
                new DateTime(dt.Year, dt.Month, dt.Day + 1, 9, 0, 0),
                new DateTime(dt.Year, dt.Month, dt.Day + 1, 10, 0, 0),
                new DateTime(dt.Year, dt.Month, dt.Day + 1, 11, 0, 0),
                new DateTime(dt.Year, dt.Month, dt.Day + 1, 12, 0, 0)
            };

            var appointments = _context.Appointments.Include(x => x.Employee)
            .Where(x => x.EmployeeId == user.Declarations.EmployeeId)
            .OrderByDescending(x => x.DateTime);

            model.Appointments = appointments;

            if (appointments == null)
            {
                List<Appointments> appList = new List<Appointments>(){
                    new Appointments(user.Declarations.EmployeeId, dates[0], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[1], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[2], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[3], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[0].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[1].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[2].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[3].AddDays(1), "free")
                };
                _context.Appointments.AddRange(appList);
                _context.SaveChanges();
                return View(model);
            }
            else if ((appointments.ToList()[0].DateTime - dt).TotalDays > 0)
            {
                if ((appointments.ToList()[0].DateTime - dt).TotalDays == 1)
                {
                    List<Appointments> appList = new List<Appointments>(){
                        new Appointments(user.Declarations.EmployeeId, dates[0].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[1].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[2].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[3].AddDays(1), "free")
                    };
                    _context.Appointments.AddRange(appList);
                    _context.SaveChanges();
                    return View(model);
                }
                else return View(model);
            }
            else if (appointments.ToList()[0].DateTime <= dt)
            {
                List<Appointments> appList = new List<Appointments>(){
                    new Appointments(user.Declarations.EmployeeId, dates[0], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[1], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[2], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[3], "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[0].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[1].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[2].AddDays(1), "free"),
                    new Appointments(user.Declarations.EmployeeId, dates[3].AddDays(1), "free")
                };
                _context.Appointments.AddRange(appList);
                _context.SaveChanges();
                return View(model);
            }
            else return Content("Not Working");
        }




        // Appointment;





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
            // await _context.SaveChangesAsync();

            return RedirectToAction("OwnerPage");

        }

    }
}

