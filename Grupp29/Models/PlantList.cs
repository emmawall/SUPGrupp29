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

		public string PlantImg { get; set; }
		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }

		public string PlantName { get; set; }

		public string Description { get; set; }

		public string WaterNeed { get; set; }

		public string Location { get; set; }
	}
}