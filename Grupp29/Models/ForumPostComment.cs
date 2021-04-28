using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp29.Models
{
	public class ForumPostComment
	{
		[Key]
		public int Id { get; set; }
		public string Author { get; set; }
		public string CommentText { get; set; }
		public DateTime DateTime { get; set; }
		public int ForumPostId { get; set; }

	}
}