using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Models
{
	public class AppointmentModel
	{
		public int BarberId { get; set; }
		public string ClientNames { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Date { get; set; } = null!;
		public string Time { get; set; } = null!;
		public string Description { get; set; }
		
	}
}
