using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Contracts
{
	public interface IAppointmentService
	{
		 Task<List<string>> GetBusyHours(int id);		
	}
}
