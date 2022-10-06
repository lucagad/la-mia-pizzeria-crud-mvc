using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers;

public class PizzaController : Controller
{
    public IActionResult Index()
    {
        List<Pizza> pizzes;

        using (PizzaContext db = new PizzaContext())
        {
            pizzes = db.Pizzas.ToList<Pizza>();
        }

        return View("Index", pizzes);
    }

    public IActionResult Show(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaFound = context.Pizzas.Where(pizza => pizza.PizzaId == id).FirstOrDefault();
            if (pizzaFound == null)
            {
                return NotFound($"La Pizza con id {id} non è stata trovata");
            }
            else
            {
                return View("Show", pizzaFound);
            }
        }
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Pizza formData)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", formData);
        }

        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaToCreate = new Pizza();
            pizzaToCreate.Name = formData.Name;
            pizzaToCreate.Description = formData.Description;
            pizzaToCreate.ImgUrl = formData.ImgUrl;
            pizzaToCreate.Price = formData.Price;
            context.Pizzas.Add(pizzaToCreate);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    