using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppointmentMaker.Infrastructure.Constraints.AppointmentConstraints;

namespace AppointmentMaker.Infrastructure.Data.Models
{

	public class Appointment
	{
		[Comment("Appointment identifier")]
		public int Id { get; set; }
		[Comment("Barber identifier")]	
		public int BarberId { get; set; }
		[ForeignKey(nameof(BarberId))]
		public Barber Barber { get; set; } = null!;
		[Required]
		[Comment("Appointment date")]
		public DateTime Date { get; set; }
		[Required]
		[Comment("Appointment time")]
		public DateTime Time { get; set; }
		[Comment("Appointment description")]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } 
		[Required]
		[Comment("Client's names")]
		[MaxLength(ClientNameMaxLength)]
		public string ClientNames { get; set; } = null!;
		[Required]
		[Comment("Client's phone number")]
		public string PhoneNumber { get; set; } = null!;


	}
}
