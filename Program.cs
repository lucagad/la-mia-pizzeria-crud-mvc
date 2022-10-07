using la_mia_pizzeria_post.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//defaultValue();


static void defaultValue()
{
    
    using (PizzaContext db = new PizzaContext()) 
    {
     
        // Creazione Pizze
        db.Add(new Pizza { PizzaId = 1, Name = "Pizza Margherita", Description = "Pizza con Pomodoro e Mozzarella", ImgUrl= "/img/pizza_margherita.jpg",Price = 6 });
        db.Add(new Pizza { PizzaId = 2, Name = "Pizza Wurstel", Description = "Pizza con Pomodoro, Mozzarella e Wurstel", ImgUrl= "/img/pizza_wurstel.jpg",Price = 8 });
        db.Add(new Pizza { PizzaId = 3, Name = "Pizza 4 Stagioni", Description = "Pizza con Pomodoro, Mozzarella, Carciofini, Funghi, Olive e Prosciutto Cotto", ImgUrl= "/img/pizza_quattro_stagioni.jpg",Price = 9 });
        
        db.SaveChanges();
            
        Console.WriteLine("Dati Inseriti");
            
    }
}