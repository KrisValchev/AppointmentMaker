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
			return await repository.AllReadOnly<Barber>()
				.Select(b => new BarbersModel
				{
					Id = b.Id,
					Name = b.BarberName
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
					.Where(a => a.BarberId == id && a.Date == dateTime)
					.Select(a => new BusyHoursModel
					{
						BarberId = a.BarberId,
						Time = a.Time.ToString(TimeFormat)
					})
					.ToListAsync();
			}
			return busyHours;
		}

		public async Task<int> MakeAppointment(AppointmentModel model)
		{
			DateTime date;
			var isValidDate = DateTime.TryParseExact(model.Date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
			DateTime time;
			var isValidTime = DateTime.TryParseExact(model.Time, TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out time);
			Appointment appointment = new Appointment();
			if (isValidDate && isValidTime)
			{
				var alreadyHasAppointment = repository.AllReadOnly<Appointment>().Any(a => a.Time == time && a.Date == date && a.BarberId == model.BarberId);
				if (!alreadyHasAppointment)
				{
					appointment = new Appointment
					{
						BarberId = model.BarberId,
						ClientNames = model.ClientNames,
						Date = date,
						Time = time,
						PhoneNumber = model.PhoneNumber,
						Description = model.Description
					};
					await repository.AddAsync<Appointment>(appointment);
					await repository.SaveChangesAsync();
				}
			}
			return appointment.Id;
		}
	}
}
