using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Data
{
	//dbContext factory class for recognising ApplicationDbContext as DbContext class so migrations can be made 
	public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			//specifying where is the connection string
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.GetFullPath("../AppointmentMaker.Server")) // Adjust as needed
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = config.GetConnectionString("DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}
