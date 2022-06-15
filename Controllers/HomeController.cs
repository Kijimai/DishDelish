using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers;

public class HomeController : Controller
{

  public IActionResult Index()
  {
    return RedirectToAction("All", "Dishes");
  }

  public IActionResult Privacy()
  {
    return View();
  }

}
