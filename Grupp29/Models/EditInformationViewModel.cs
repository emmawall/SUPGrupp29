using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
    public class EditInformationViewModel
    {
        [StringLength(100, ErrorMessage = "Användarnamnet måste vara minst 2 tecken långt.", MinimumLength = 2)]
        [Display(Name = "Användarnamn")]
        public string DisplayName { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
    }
}