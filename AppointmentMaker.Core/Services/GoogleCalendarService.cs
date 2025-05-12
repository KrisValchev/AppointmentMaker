using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Core.Services
{
	//to use it you should have service account created and added to the calendar 
	public class GoogleCalendarService
	{
		private readonly string _calendarId = "INSERT_YOUR_CALENDAR_ID_HERE"; //change to your calendar id // or a shared calendar ID 

		public async Task InsertEvent(string summary, string description, DateTime start)
		{
			// Define a GoogleCredential object to hold the service account credentials
			GoogleCredential credential;

			// Build the full path to the service account JSON key file (located in App_Data)
			var keyPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "calendar-key.json");

			// Load the service account credentials from the JSON key file and scope it to Calendar API access
			using (var stream = new FileStream(keyPath, FileMode.Open, FileAccess.Read))
			{
				credential = GoogleCredential.FromStream(stream)
					.CreateScoped(CalendarService.Scope.Calendar);
			}

			// Initialize the Calendar service with the loaded credentials and set the app name
			var service = new CalendarService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "Haircut Booking App",// Name shown in API dashboard and logs
			});

			// Format the start date to ISO format (yyyy-MM-dd) as a whole-day event start
			string startDate = start.ToString("yyyy-MM-dd");

			DateTime end = start.AddDays(1);

			// Create a new full-day Google Calendar event (no specific time, just date)
			string endDate = end.ToString("yyyy-MM-dd");


			var newEvent = new Event()
			{
				Summary = summary,
				Description = description,
				Start = new EventDateTime()
				{
					Date = startDate,
				},
				End = new EventDateTime()
				{
					Date = endDate,
				},
			};
			// Insert the new event into the target calendar identified by _calendarId
			var request = service.Events.Insert(newEvent, _calendarId);
			 await request.ExecuteAsync();
			
		}
	}
}
