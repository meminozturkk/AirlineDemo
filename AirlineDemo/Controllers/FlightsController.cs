using AirlineDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineDemo.Controllers
{
    public class FlightsController : Controller
    {

		public List<Flight> FlightsInCart
		{
			get
			{
				return Session["Flights"] as List<Flight>;
			}
			set
			{
				Session["Flights"] = value;
			}
		}
		public ActionResult AddToVoucher(string flightCode)
		{
			if (FlightsInCart == null)
			{
				FlightsInCart = new List<Flight>();
			}

			FlightRepository flightRepository = FlightRepository.GetFlightRepository();
			var flight = flightRepository.GetFlightByCode(flightCode);

			if (flight != null)
			{
				FlightsInCart.Add((Flight)flight);
			}

			var flights = FlightRepository.GetAllFlights();

			return View("Index", flights);
		}
		// GET: Flights
		public ActionResult Index()
        {
			FlightRepository flightRepository = FlightRepository.GetFlightRepository();

			IEnumerable<Flight> flights = FlightRepository.GetAllFlights();

			return View(flights);
		}

		public ActionResult Search(DateTime? dateOfFlight)
		{
			if (dateOfFlight.HasValue && dateOfFlight.Value.Date < DateTime.Now.Date)
			{
				ModelState.AddModelError("", "Flight date cannot be set to an earlier day than today.");
			}

			FlightRepository flightRepository = FlightRepository.GetFlightRepository();
			var flights = flightRepository.GetFlightsOnSpecificDate(dateOfFlight);
			return View(flights);
		}
		public ActionResult Detail(string flightCode)
		{

			var flight = FlightRepository.GetAllFlights().SingleOrDefault(f => f.Code == flightCode);

			if (flight == null)
			{
				return HttpNotFound();
			}
			
			return View(flight);
		}
		
	}
}