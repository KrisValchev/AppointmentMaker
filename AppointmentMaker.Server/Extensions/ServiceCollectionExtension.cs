using AppointmentMaker.Core.Contracts;
using AppointmentMaker.Core.Services;
using AppointmentMaker.Infrastructure.Common;
using AppointmentMaker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentMaker.Server.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{

			services.AddScoped<IAppointmentService, AppointmentService>();
			services.AddScoped< GoogleCalendarService>();
			return services;
		}

		//extension for specifying where to seek the connection string
		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));
			services.AddScoped<IRepository, Repository>();
			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}
	}
}
