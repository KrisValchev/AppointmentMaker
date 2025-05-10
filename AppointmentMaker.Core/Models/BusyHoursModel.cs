using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Models
{
	public class BusyHoursModel
	{
		public int BarberId {  get; set; }
		public string Time { get; set; } = null!;
		
	}
}
