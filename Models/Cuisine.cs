using System.ComponentModel.DataAnnotations;

namespace GourmandGurus.Models
{
    public class Cuisine
    {
        public int ID { get; set; }

        [Display(Name = "Cuisine")]
        public string CuisineName { get; set; }

        public string Description { get; set; }

        public ICollection<Recipe>? Recipes { get; set; }
    }
}
