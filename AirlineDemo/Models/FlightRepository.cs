using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineDemo.Models
{
	public class FlightRepository
	{
		// for singleton pattern
		private static FlightRepository flightRepository;
		private static List<Flight> flights;

		public FlightRepository()
		{
			flights = new List<Flight>()
			{
				new Flight() {Code= "0001" , Date = DateTime.Now , Departure = "Istanbul" , Arrival = "Izmir"},
				new Flight() { Code = "0002", Date = DateTime.Parse("20.07.2023"), Departure = "Adana", Arrival = "Ankara" },
				new Flight() { Code = "0003", Date = DateTime.Now, Departure = "Kahramanmaras", Arrival = "Trabzon" }

			};

		}
		//for singleton pattern
		public static FlightRepository GetFlightRepository()
		{
			if (flightRepository == null)
			{
				flightRepository = new FlightRepository();
			}
			return flightRepository;
		}

		public static IEnumerable<Flight> GetAllFlights()
		{
			return flights;
		}
		public IEnumerable<Flight> GetFlightsOnSpecificDate(DateTime? dateOfFlight)
		{
			if (!dateOfFlight.HasValue )
			{
				return flights;
			}
			
			return flights.Where(c => c.Date.Date == dateOfFlight.Value.Date).ToList();
			
		}

		internal Flight GetFlightByCode(string flightCode)
		{
			return FlightRepository.GetAllFlights().SingleOrDefault(f => f.Code == flightCode);
		}
	}
}