using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace GourmandGurus.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Display(Name = "Recipe Name")]

        [Required(ErrorMessage = "Recipe name is required.")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "Instructions are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Instructions are required.")]
        public string Instructions { get; set; }


        [Required(ErrorMessage = "Cooking time is required.")]
        public TimeSpan CookingTime { get; set; }

        public bool Vegetarian { get; set; }

        public int? CuisineID { get; set; }

        [Display(Name = "Cuisine")]
       
        public Cuisine? Cuisine { get; set; }

        public int? CategoryID { get; set; }
        
        [Display(Name = "Category")]
       
        public Category? Category { get; set; }

       

    }
}
