using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers;

public class EserciziController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}