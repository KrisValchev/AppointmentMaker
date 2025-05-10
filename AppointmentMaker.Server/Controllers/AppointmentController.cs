using AppointmentMaker.Core.Contracts;
using AppointmentMaker.Core.Models;
using AppointmentMaker.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AppointmentMaker.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
	{
		[HttpGet("get-busy-hours/{id}/{date}")]
		public async Task<ActionResult<IEnumerable<BusyHoursModel>>> GetBusyHours(int id,string date)
		{

			return await appointmentService.GetBusyHours(id,date); 
			
		}
		[HttpGet("get-barbers")]
		public async Task<ActionResult<IEnumerable<BarbersModel>>> GetBarbers()
		{

			return await appointmentService.GetBarbers();

		}
	}
}
