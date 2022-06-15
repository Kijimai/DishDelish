using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

public class DishesController : Controller
{
  private DishContext _context;

  public DishesController(DishContext context)
  {
    _context = context;
  }

  [HttpGet("/dishes/new")]
  public IActionResult New()
  {
    return View("New");
  }

  [HttpPost("/dishes/create")]
  public IActionResult Create(Dish newDish)
  {
    if (ModelState.IsValid)
    {
      _context.Dishes.Add(newDish);
      _context.SaveChanges();
      return RedirectToAction("All");
    }
    return New();
  }

  [HttpGet("/dishes/all")]
  public IActionResult All()
  {
    List<Dish> AllDishes = _context.Dishes.ToList();
    return View("All", AllDishes);
  }

  [HttpGet("/dishes/{postId}")]
  public IActionResult Details(int postId)
  {
    Dish? foundDish = _context.Dishes.FirstOrDefault(dish => dish.PostId == postId);

    if (foundDish != null)
    {
      return View(foundDish);
    }
    return RedirectToAction("All");
  }

  [HttpGet("/dishes/{postId}/edit")]
  public IActionResult Edit(int postId)
  {
    Dish? foundDish = _context.Dishes.FirstOrDefault(dish => dish.PostId == postId);

    if (foundDish != null)
    {
      return View("Edit", foundDish);
    }
    return RedirectToAction("All");
  }

  [HttpPost("/dishes/{postId}/update")]
  public IActionResult Update(Dish updatedDish, int postId)
  {
    if (ModelState.IsValid)
    {
      Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.PostId == postId);

      if (dish != null)
      {
        dish.Name = updatedDish.Name;
        dish.Chef = updatedDish.Chef;
        dish.Calories = updatedDish.Calories;
        dish.Tastiness = updatedDish.Tastiness;
        dish.Description = updatedDish.Description;
        dish.UpdatedAt = DateTime.Now;

        _context.Dishes.Update(dish);
        _context.SaveChanges();
      }
      return RedirectToAction("Details", postId);
    }
    else
    {
      return Edit(postId);
    }
  }

  [HttpPost("/dishes/{postId}/delete")]
  public IActionResult Delete(int postId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.PostId == postId);

    if (dish != null)
    {
      _context.Dishes.Remove(dish);
      _context.SaveChanges();
    }
    return RedirectToAction("All");
  }
}