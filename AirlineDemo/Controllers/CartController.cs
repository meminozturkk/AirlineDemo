using AirlineDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineDemo.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
			List<Flight> flights = Session["Flights"] as List<Flight>;

			return View(flights);
		}
    }
}