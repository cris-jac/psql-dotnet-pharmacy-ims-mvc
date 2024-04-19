using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly UserManager<AppUser> _userManager;

    public EmployeesController(
        IEmployeeRepository employeeRepository,
        UserManager<AppUser> userManager
    )
    {
        _employeeRepository = employeeRepository;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeeRepository.GetAllEmployees();

        var employeeList = new List<EmployeeViewModel>();

        foreach (var emp in employees)
        {
            var employeeViewModel = new EmployeeViewModel
            {
                Id = emp.Id,
                FirstName = emp.UserName,
                LastName = emp.UserName,
                UserName = emp.UserName,
                Email = emp.Email,
                Phone = emp.PhoneNumber,
                Position = emp.Position,
                StartingDate = emp.StartingDate,
                PictureUrl = emp.PictureUrl,
                IsActive = emp.IsActive
            };

            employeeList.Add(employeeViewModel);
        }

        return View(employeeList);
    }

    [HttpGet, Route("/employees/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var user = await _employeeRepository.GetUserById(id);
        if (user == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var employeeViewModel = new EmployeeViewModel
        {
            Id = user.Id,
            FirstName = user.UserName,
            LastName = user.UserName,
            UserName = user.UserName,
            Email = user.Email,
            Phone = user.PhoneNumber,
            Position = user.Position,
            StartingDate = user.StartingDate,
            PictureUrl = user.PictureUrl,
            IsActive = user.IsActive
        };

        return View(employeeViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return View("Error");
        }

        var editUserViewModel = new EditUserViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            DocumentType = user.DocumentType,
            DocumentNumber = user.DocumentNumber,
            Email = user.Email,
            Phone = user.PhoneNumber,
            PictureUrl = user.PictureUrl
        };

        return View(editUserViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(EditUserViewModel editUserViewModel)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Error al modificar tu cuenta");
            return View("EditProfile", editUserViewModel);
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return View("Error");
        }

        user.PhoneNumber = editUserViewModel.Phone;
        user.Email = editUserViewModel.Email;
        user.UserName = editUserViewModel.UserName;
        user.PictureUrl = editUserViewModel.PictureUrl;
        user.FirstName = editUserViewModel.FirstName;
        user.LastName = editUserViewModel.LastName;
        user.UserName = editUserViewModel.UserName;
        user.DocumentType = editUserViewModel.DocumentType;
        user.DocumentNumber = editUserViewModel.DocumentNumber;

        await _userManager.UpdateAsync(user);
        return RedirectToAction("Details", "Employees", new { user.Id });
    }
}