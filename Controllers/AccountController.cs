using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaMVC.Data;
using PharmaMVC.Models;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ApplicationDbContext _dbContext;

    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext dbContext
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
    }

    public IActionResult Login()
    {
        var loginViewModel = new LoginViewModel();
        return View(loginViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View(loginViewModel);

        var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Error"] = "Credenciales incorrectos";
            return View(loginViewModel);
        }

        TempData["Error"] = "Credenciales incorrectos";
        return View(loginViewModel);
    }

    public IActionResult Register()
    {
        var registerViewModel = new RegisterViewModel();
        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Verifique los datos ingresados";
            return View(registerViewModel);
        }

        var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
        if (user != null)
        {
            TempData["Error"] = "Este email esta en uso";
            return View(registerViewModel);
        }

        var newUser = new AppUser()
        {
            Email = registerViewModel.Email,
            UserName = registerViewModel.Email
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

        if (newUserResponse.Succeeded)
        {
            await _userManager.AddToRoleAsync(newUser, StaticRoles.User);
            return RedirectToAction("Login");
        }

        TempData["Error"] = "Verifique los datos ingresados";
        return View(registerViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}