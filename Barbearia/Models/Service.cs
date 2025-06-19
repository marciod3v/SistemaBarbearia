using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbearia.Models
{
	public class Service
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public TimeSpan Duration { get; set; }
	}
}