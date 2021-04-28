using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class ForumPostCategory
	{
		[Key]
		[Display(Name = "Kategori")]
		public string CategoryName { get; set; }
	}
}