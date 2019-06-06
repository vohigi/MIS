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

namespace MIS.Controllers
{
  public class AccountController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AccountController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _context = context;
      _userManager = userManager;
      _signInManager = signInManager;
    }


    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        User user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
        // добавляем пользователя
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          // установка куки
          var res = await _userManager.AddToRoleAsync(user, "user");
          if (res.Succeeded)
          {
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
          }

        }
        else
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError(string.Empty, error.Description);
          }
        }
      }
      return View(model);
    }
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
      return View(new LoginViewModel { ReturnUrl = returnUrl });
    }
    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      if (ModelState.IsValid)
      {
        var result =
            await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (result.Succeeded)
        {
          // проверяем, принадлежит ли URL приложению
          if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
          {
            return Redirect(model.ReturnUrl);
          }
          else
          {
            return RedirectToAction("Index", "Home");
          }
        }
        else
        {
          ModelState.AddModelError("", "Неправильный логин и (или) пароль");
        }
      }
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
      // удаляем аутентификационные куки
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}