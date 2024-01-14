using System.ComponentModel.DataAnnotations;

namespace GourmandGurus.Models
{
    public class Member
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The first letter of the first name must be capitalized (e.g., Ana or Ana Maria or Ana-Maria)")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "The first letter of the last name must be capitalized (e.g., Ana or Ana Maria or Ana-Maria)")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone number must be formatfed like this '0722-123-123' or '0722.123.123' or '0722 123 123'")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
