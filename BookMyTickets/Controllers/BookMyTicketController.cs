using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyTickets.Controllers
{
    public class BookMyTicketController : Controller
    {
        // GET: BookMyTicket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BookingDetails(int? Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult BookingSuccessful()
        {
            return View();
        }
        public ActionResult BookingFailed()
        {
            return View();
        }
    }
}