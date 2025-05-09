using AppointmentMaker.Infrastructure.Data.Models;
using static AppointmentMaker.Infrastructure.Constraints.AppointmentConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Data.SeedDb
{
	internal class SeedData
	{
		public SeedData()
		{
			SeedBarbers();
			SeedAppointments();
		}
		public Barber Barber { get; set; }

		public Appointment Appointment1 { get; set; }
		public Appointment Appointment2 { get; set; }

		private void SeedBarbers()
		{
			Barber = new Barber
			{
				Id = 1,
				BarberName = "Denis"
			};
		}
		private void SeedAppointments()
		{
			Appointment1 = new Appointment
			{
				Id = 1,
				BarberId = 1,
				Date = DateTime.Parse("12-05-2025"),
				Time = DateTime.Parse("12:00"),
				ClientNames = "Petar Ivanov",
				PhoneNumber = "0871234567",
				Description=""
			};
			Appointment2 = new Appointment
			{
				Id = 2,
				BarberId = 1,
				Date = DateTime.Parse("12-05-2025"),
				Time = DateTime.Parse("12:30"),
				ClientNames = "Mihail Dimitrov",
				PhoneNumber = "0870000000",
				Description = ""
			};
		}
	}
}
