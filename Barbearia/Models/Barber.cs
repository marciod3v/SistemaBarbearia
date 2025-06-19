using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbearia.Models
{
	public class Barber
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public TimeSpan StartTimeWork { get; set; }
		public TimeSpan EndTimeWork { get; set; }
		public int DefaultDurationService { get; set; }
    }
}