using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookMyTickets.Service;
using BookMyTickets.Service.Models;
using BookMyTicketConnectionString;
using BookMyTickets.Service.Automapper;

namespace BookMyTickets.Controllers.API
{
    public class BookMyTicketController : ApiController
    {
        private IOnlineMovieTicketBookingService BookingService;

        public BookMyTicketController(IOnlineMovieTicketBookingService bookingService)
        {
            this.BookingService = bookingService;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var Movies = this.BookingService.GetMovies();
            return Movies;
        }
        
        public Movie GetMovie([FromUri]int id)
        {
            var Movie = this.BookingService.GetMovie(id);
            return Movie;
        }

        public List<TheaterMovieTheater> GetTheaters([FromUri]int id)
        {
            return this.BookingService.GetTheaters(id);
        }

        public TheaterShowTime GetDates([FromUri]int id)
        {
            return this.BookingService.GetDates(id);
        }

        public List<TheaterShowTimeShow> GetShows([FromUri]int id)
        {
            return this.BookingService.GetShows(id);
        }
        
        public TheaterMovieSeatCost GetTheaterLayout([FromUri]int id)
        {
            return this.BookingService.GetTheaterLayout(id);
        }

        public TheaterMovieTheaterMovie GetTheaterAndMovie([FromUri]int id)
        {
            return this.BookingService.GetTheaterAndMovie(id);
        }

        [HttpPost]
        public Ticket BookTicket(TicketSeatReservation ticketSeatReservation)
        {
            ticket_seat_reservation ticket = ticketSeatReservation.MapFrom<TicketSeatReservation, ticket_seat_reservation>();

            return this.BookingService.BookTicket(ticket);
        }

        public List<string> GetReservedSeats([FromUri] ShowDetails showDetails)
        {
            return this.BookingService.GetReservedSeats(showDetails);
        }
    }
}
