using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class PlantRoom
	{
		[Key]
		public int Id { get; set; }
		public virtual RoomList roomlist { get; set; }

		public virtual PlantList plantlist { get; set; }
	}
}