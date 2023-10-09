using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsAndDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dishes")]
    public IActionResult AllDishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(t => t.Creator).ToList();

        return View("Dishes", AllDishes);
    }



    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.TheChefs = _context.Users.ToList();
        return View("DishForm");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.TheChefs = _context.Users.ToList();
            return View("DishForm");
        }

        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("AllDishes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
