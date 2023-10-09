using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsAndDishes.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {

        List<User> AllChefs = _context.Users.Include(t => t.AllDishes).ToList();
        return View("Index", AllChefs);
    }

    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {

        return View("ChefForm");
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(User newChef)
    {
        if (!ModelState.IsValid)
        {
            return View("ChefForm");
        }

        _context.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // [HttpGet("dishes")]
    // public IActionResult AllDishes()
    // {
    //     List<Dish> AllDishes = _context.Dishes.OrderByDescending(t => t.CreatedAt).ToList();

    //     return View("Dishes", AllDishes);
    // }



    // [HttpGet("dishes/new")]
    // public IActionResult NewDish()
    // {

    //     return View("DishForm");
    // }

    // [HttpPost("dishes/create")]
    // public IActionResult CreateDish(Dish newDish)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View("DishForm");
    //     }

    //     _context.Add(newDish);
    //     _context.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
