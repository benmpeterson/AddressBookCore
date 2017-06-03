using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Contact
    {
        public int id { get; set; }
        [Required, MaxLength(30)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(30)]
        [Display(Name="Phone Name")]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}