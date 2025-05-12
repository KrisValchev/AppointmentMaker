using AppointmentMaker.Core.Contracts;
using AppointmentMaker.Core.Models;
using AppointmentMaker.Core.Services;
using Google.Apis.Calendar.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AppointmentMaker.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController(IAppointmentService appointmentService, GoogleCalendarService _calendarService) : ControllerBase
	{
		[HttpGet("get-busy-hours/{id}/{date}")]
		public async Task<ActionResult<IEnumerable<BusyHoursModel>>> GetBusyHours(int id, string date)
		{

			return await appointmentService.GetBusyHours(id, date);

		}
		[HttpGet("get-barbers")]
		public async Task<ActionResult<IEnumerable<BarbersModel>>> GetBarbers()
		{

			return await appointmentService.GetBarbers();

		}

		[HttpPost("make-appointment")]
		public async Task<IActionResult> MakeAppointment(AppointmentModel model)
		{
			var newAppointment = await appointmentService.MakeAppointment(model);
			return Ok(newAppointment);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAppointment([FromBody] AppointmentRequestModel request)
		{
			await _calendarService.InsertEvent(
				$"Haircut Appointment for {request.BarberName}",
				$"{request.ClientName} ({request.Phone}) for {request.Time} - {request.Description}",
				request.StartTime
			);


			return Ok(new { message = "Appointment added to calendar!" });

		}
	}
}
