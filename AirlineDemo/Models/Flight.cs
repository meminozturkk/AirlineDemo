using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirlineDemo.Models
{
	public class Flight
	{
		[DisplayName("Flight code:")]
		public string Code { get; set; }

		[DisplayName("Flight date:")]
		public DateTime Date { get; set; }

		[DisplayName("Take off from:")]
		public string Departure { get; set; }

		[DisplayName("Lands to:")]
		public string Arrival { get; set; }
	}
}