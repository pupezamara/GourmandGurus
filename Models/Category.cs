using System.ComponentModel.DataAnnotations;

namespace GourmandGurus.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Recipe>? Recipes { get; set; } 
    }
}
