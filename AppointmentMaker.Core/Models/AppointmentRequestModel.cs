using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Models
{
	public class AppointmentRequestModel
	{
		public string ClientName { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string BarberName { get; set; } = null!;
		public string Description { get; set; }
		public string Time { get; set; } = null!;
		public DateTime StartTime { get; set; }
	}
}
