using AppointmentMaker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
		}
		public DbSet<Appointment> Appointments { get; set; } = null!;
		public DbSet<Barber> Barbers { get; set; } = null!;

	}
}
