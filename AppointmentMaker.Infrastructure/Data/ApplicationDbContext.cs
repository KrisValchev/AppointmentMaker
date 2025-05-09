using AppointmentMaker.Infrastructure.Data.Models;
using AppointmentMaker.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Data
{
	public class ApplicationDbContext:DbContext
	{
		public DbSet<Appointment> Appointments { get; set; } = null!;
		public DbSet<Barber> Barbers { get; set; } = null!;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new BarberConfiguration());
			builder.ApplyConfiguration(new AppointmentConfiguration());
			base.OnModelCreating(builder);	
		}
	}
}
