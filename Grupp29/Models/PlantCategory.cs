using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class PlantCategory
	{
		[Key]
		[Display(Name = "Växtkategori")]
		public string PlantCategoryName { get; set; }
	}
}