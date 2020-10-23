using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiModels
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "IIN must contain digits only.")]
        public string IIN { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain letters only.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain letters only.")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}