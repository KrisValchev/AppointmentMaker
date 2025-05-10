
using AppointmentMaker.Server.Extensions;

namespace AppointmentMaker.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			// Add CORS services
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin()    // Allow all origins
						  .AllowAnyMethod()    // Allow all HTTP methods
						  .AllowAnyHeader();   // Allow all headers
				});
			});
			// Add services to the container.
			builder.Services.AddApplicationDbContext(builder.Configuration);
			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServices();


			    var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
			// Enable CORS before routing
			app.UseCors("AllowAll");

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();

			app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
			
		}
    }
}
