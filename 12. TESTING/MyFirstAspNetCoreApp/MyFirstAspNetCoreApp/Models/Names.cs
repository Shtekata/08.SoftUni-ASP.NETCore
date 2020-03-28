using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MyFirstAspNetCoreApp.Models
{
    public class Names
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
