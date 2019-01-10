using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyTickets.Service.Models;
using BookMyTicketConnectionString;

namespace BookMyTickets.Service
{
    public interface IOnlineMovieTicketBookingService
    {
        List<Movie> GetMovies();
        Movie GetMovie(int id);
        List<TheaterMovieTheater> GetTheaters(int movie_id);
        TheaterShowTime GetDates(int theaterMovieId);
        List<TheaterShowTimeShow> GetShows(int theaterMovieId);
        TheaterMovieSeatCost GetTheaterLayout(int theaterMovieId);
        TheaterMovieTheaterMovie GetTheaterAndMovie(int theaterMovieId);
        Ticket BookTicket(ticket_seat_reservation ticketSeatReservation);
        List<string> GetReservedSeats(ShowDetails showDetails);
    }
}
