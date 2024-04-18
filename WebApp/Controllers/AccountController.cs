using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize]

public class AccountController(UserManager<UserEntity> userManager, ApplicationContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly ApplicationContext _context = context;

    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if(TryValidateModel(model.Basic!))
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;
                user.Email = user.Email;
                user.PhoneNumber = user.PhoneNumber;
                user.UserName = user.Email;
                user.Bio = user.Bio;
            }
        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information.";
        }

        
        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (TryValidateModel(model.Address!))
        {

        }
        else
        {
            TempData["StatusMessage"] = "Unable to save address information.";
        }

        
        return RedirectToAction("Details", "Account");
    }
}
