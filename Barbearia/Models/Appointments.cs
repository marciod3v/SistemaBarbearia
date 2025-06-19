using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbearia.Models
{
    public enum AppointmentStatus
    {
        Scheduled,  
        Completed,  
        Cancelled, 
        NoShow 
    }
    public class Appointments
	{
		public int Id { get; set; }
		public Models.Client Client { get; set; }
		public Models.Barber Barber { get; set; }
		public Models.Service Service { get; set; }
		public TimeSpan StartTimeWork { get; set; }
		public TimeSpan EndTimeWork { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}