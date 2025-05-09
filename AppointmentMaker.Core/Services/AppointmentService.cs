using AppointmentMaker.Core.Contracts;
using static AppointmentMaker.Infrastructure.Constraints.AppointmentConstraints;
using AppointmentMaker.Infrastructure.Common;
using AppointmentMaker.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AppointmentMaker.Core.Services
{
	public class AppointmentService(IRepository repository) :IAppointmentService
	{	
		public async Task<List<string>> GetBusyHours(int id)
		{
			var busyHours=await repository.AllReadOnly<Appointment>()
				.Where(a=>a.BarberId==id)
				.Select(a=> a.Time.ToString(TimeFormat))
				.ToListAsync();
			return busyHours;
		}
	}
}
