using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class Forum
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Titel")]
		public string Title { get; set; }

		[Display(Name = "Inlägg")]
		public string Entry { get; set; }

		[Display(Name = "Författare")]
		public string Creator { get; set; }

		[Display(Name = "Datum")]
		public DateTime DateTime { get; set; }

		[Display(Name = "Kategori")]
		public string Category { get; set; }

		[Display(Name = "Bild")]
		public string FileName { get; set; }
	}
}