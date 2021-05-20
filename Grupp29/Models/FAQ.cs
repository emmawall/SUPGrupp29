using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Din mail:")]
        public string Sender { get; set; }


        [Display(Name = "Meddelande:")]
        public string Message { get; set; }
    }
}