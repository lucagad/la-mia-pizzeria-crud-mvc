using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

public class PizzaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=db_pizzeria;Persist Security Info=True;User ID=sa;Password=NET2022!");
    }
    
}