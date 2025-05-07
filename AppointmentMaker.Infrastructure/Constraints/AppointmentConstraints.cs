using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Constraints
{
	public static class AppointmentConstraints
	{
		public const string DateFormat = "dd-MM-yyyy";
		public const string TimeFormat = "HH:mm";

		public const int DescriptionMinLength = 5;
		public const int DescriptionMaxLength = 1000;

		public const int ClientNameMinLength = 2;
		public const int ClientNameMaxLength = 50;
	}
}
