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
            if (formData.ImgUrl != null)
            {
                pizzaToCreate.ImgUrl = formData.ImgUrl;
            }
            else
            {
                pizzaToCreate.ImgUrl="/img/placeholder.jpg";
            }
            pizzaToCreate.Price = formData.Price;
            
            context.Pizzas.Add(pizzaToCreate);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaSelected = context.Pizzas.Where(Pizza => Pizza.PizzaId == id).FirstOrDefault();
            if (pizzaSelected == null)
            {
                return NotFound("Pizza non trovata");
            }
            return View (pizzaSelected);
        }
    }

    [HttpPost]
    public IActionResult Update(int id, Pizza formData)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaSelected = context.Pizzas.Where(pizza => pizza.PizzaId == id).FirstOrDefault();
            pizzaSelected.Name = formData.Name;
            pizzaSelected.Description = formData.Description;
            pizzaSelected.ImgUrl = formData.ImgUrl;
            pizzaSelected.Price = formData.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizza = context.Pizzas.Where(Pizza => Pizza.PizzaId == id).FirstOrDefault();
            if (pizza == null)
            {
               return NotFound("Non trovato");
            }
            context.Pizzas.Remove(pizza);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}