using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppointmentMaker.Infrastructure.Constraints.BarberDataConstraints;

namespace AppointmentMaker.Infrastructure.Data.Models
{
	public class Barber
	{
		[Comment("Barber identifier")]
		public int Id { get; set; }
		[Required]
		[Comment("Barber's name")]
		[MaxLength(BarberNameMaxLength)]
		public string BarberName { get; set; } = null!;
		

	}
}
