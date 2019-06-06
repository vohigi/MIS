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
    public IActionResult OwnerPage() => View();
    public async Task<IActionResult> ChooseDoctor()
    {
      var _e = await _userManager.GetUsersInRoleAsync("doctor");
      var selected = _context.Users.Include(x => x.Msp).Where(u => _e.Contains(u));
      //.Include(x => x.Msp).ToListAsync();
      return View(_e);
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
      return View(doctor);
    }
  }
}
