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
using AppointmentMaker.Core.Models;
using System.Globalization;


namespace AppointmentMaker.Core.Services
{
	public class AppointmentService(IRepository repository) : IAppointmentService
	{
		public async Task<List<BarbersModel>> GetBarbers()
		{
			var barbers = await repository.AllReadOnly<Barber>().ToListAsync();
			return await repository.AllReadOnly<Appointment>()
				.Select(a => new BarbersModel
				{
					Id = a.Id,
					Name=a.Barber.BarberName
				})
				.ToListAsync();

		}

		public async Task<List<BusyHoursModel>> GetBusyHours(int id, string date)
		{
			DateTime dateTime;
			var isDate = DateTime.TryParseExact(date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
			List<BusyHoursModel> busyHours = new List<BusyHoursModel>();
			if (isDate)
			{
				busyHours = await repository.AllReadOnly<Appointment>()
					.Where(a => a.BarberId == id && a.Date==dateTime)	
					.Select(a => new BusyHoursModel
					{
						BarberId = a.BarberId,
						Time = a.Time.ToString(TimeFormat)
					})
					.ToListAsync();
			}
			return busyHours;
		}
	}
}
