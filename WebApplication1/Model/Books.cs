using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
	public class Books
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Rating { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
	}
}
