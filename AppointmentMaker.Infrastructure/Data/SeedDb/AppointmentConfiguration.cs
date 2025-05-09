using AppointmentMaker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Data.SeedDb
{
	public class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			var data = new SeedData();
			builder.HasData(new Appointment[] { data.Appointment1,data.Appointment2 });
		}

	}
}
