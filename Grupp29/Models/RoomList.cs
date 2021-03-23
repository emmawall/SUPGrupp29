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
        public string listName { get; set; }
    }
}