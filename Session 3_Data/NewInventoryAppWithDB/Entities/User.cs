using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[Required]
		[StringLength(32)]
		public string Password { get; set; }

		[Required]
		public bool IsAdmin { get; set; }
	}

	public class UserNameIsAdminBDSet
	{		
		public string Name { get; set; }
		public bool IsAdmin { get; set; }
	}
}
