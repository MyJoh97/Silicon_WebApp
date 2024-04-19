using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]

public class CoursesController : Controller
{
    private readonly HttpClient _httpClient;

    public IActionResult Index()
    {
        return View();
    }
}
