using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grupp29.Models
{
    public class RoomList
    {
        [Key]
        public int id { get; set; }

        public virtual ApplicationUser listId { get; set; }

        [Display(Name = "Listnamn")]
        public string listName { get; set; }

        public string ListCreator { get; set; }

        public string PlantContent { get; set; }
    }
}