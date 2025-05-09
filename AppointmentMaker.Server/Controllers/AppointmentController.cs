using AppointmentMaker.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMaker.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController(AppointmentService appointmentService) : ControllerBase
	{
		[HttpGet("get-busy-hours/{id}")]
		public async Task<IActionResult> GetBusyHours(int id)
		{
			var busyHours=await appointmentService.GetBusyHours(id);
			return Ok(busyHours);
		}
	}
}
