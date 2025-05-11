using AppointmentMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Contracts
{
	public interface IAppointmentService
	{
		 Task<List<BusyHoursModel>> GetBusyHours(int id,string date);		
		 Task<List<BarbersModel>> GetBarbers();		
		Task<int> MakeAppointment(AppointmentModel model);
	}
}
