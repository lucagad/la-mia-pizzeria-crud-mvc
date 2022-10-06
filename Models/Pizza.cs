using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_post;

namespace la_mia_pizzeria_static.Models;

[Table("pizza")]
public class Pizza
{
    [Key]
    public int PizzaId { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (100, ErrorMessage = "La descrizione non può avere più di 100 caratteri")]
    [MoreThanFiveWordValidation]
    public string Description  { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (50, ErrorMessage = "L'URL non può avere più di 50 caratteri")]
    public string ImgUrl { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [Range(0.01, 999.99, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 ed 999.99")]
    public double Price { get; set; }

    public Pizza()
    {
        
    }
    public Pizza(string name, string description, string img , double price)
    {
        Name = name;
        Description = description;
        ImgUrl = img;
        Price = price;
    }

}