using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class PlantList
	{
		[Key]

		public int PlantId { get; set; }

		[Display(Name = "")]
		public string PlantImg { get; set; }

		[Display(Name = "Namn")]
		public string PlantName { get; set; }

		[Display(Name = "Beskrivning")]
		public string Description { get; set; }

		[Display(Name = "Vattenbehov")]
		public string WaterNeed { get; set; }

		[Display(Name = "Läge")]
		public string Location { get; set; }

		[Display(Name = "Kategori")]
		public string PlantCategory { get; set; }
	}
}