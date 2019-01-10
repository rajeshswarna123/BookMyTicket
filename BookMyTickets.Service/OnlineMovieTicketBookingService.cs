using BookMyTicketConnectionString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyTickets.Service.Automapper;
using BookMyTickets.Service.Models;

namespace BookMyTickets.Service
{
    public class OnlineMovieTicketBookingService : IOnlineMovieTicketBookingService
    {
        public BookMyTicketConnectionStringDB context { get; set; }

        public OnlineMovieTicketBookingService(BookMyTicketConnectionStringDB _context)
        {
            this.context = _context;
        }

        #region Online Movie Ticket Booking Service(s)

        public List<Movie> GetMovies()
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("Movie");
            return (context.Fetch<movie>(sql)).MapToCollection<movie, Movie>();
        }
        public Movie GetMovie(int Id)
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("Movie").Where("Id=@0", Id);
            return (context.FirstOrDefault<movie>(sql)).MapTo<movie, Movie>();
        }

        public List<TheaterMovieTheater> GetTheaters(int movieId)
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("Theater").InnerJoin("theater_movie").On("(theater_movie.movie_id = @0) AND (theater.ID = theater_movie.theater_id)", movieId);
            var result = (context.Fetch<theater_movie_theater>(sql)).MapToCollection<theater_movie_theater, TheaterMovieTheater>();
            return result;
        }

        public TheaterShowTime GetDates(int theaterMovieId)
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("theater_show_time").Where("theater_movie_id = @0", theaterMovieId);
            var result = (context.FirstOrDefault<theater_show_time>(sql)).MapTo<theater_show_time, TheaterShowTime>();
            return result;
        }

        public List<TheaterShowTimeShow> GetShows(int theaterMovieId)
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("theater_show_time").InnerJoin("show").On("(theater_show_time.theater_movie_id = @0) AND (show.ID = theater_show_time.show_id)", theaterMovieId);
            var result = (context.Fetch<theater_show_time_show>(sql)).MapToCollection<theater_show_time_show, TheaterShowTimeShow>();
            return result;
        }

        public TheaterMovieSeatCost GetTheaterLayout(int theaterMovieId)
        {
            var sql = PetaPoco.Sql.Builder.Select("*").From("theater_movie").InnerJoin("seat_cost").On("(theater_movie.theater_id = seat_cost.theater_id) AND (theater_movie.id = @0)", theaterMovieId);
            var result = (context.FirstOrDefault<theater_movie_seat_cost>(sql)).MapTo<theater_movie_seat_cost, TheaterMovieSeatCost>();
            return result;
        }

        public TheaterMovieTheaterMovie GetTheaterAndMovie(int theaterMovieId)
        {
            var sql = PetaPoco.Sql.Builder.Select("movie.Title, theater.Name, theater_movie.ID").From("theater").InnerJoin("theater_movie").On("(theater.ID = theater_movie.theater_id) AND (theater_movie.id = @0)", theaterMovieId).InnerJoin("movie").On("(movie.ID = theater_movie.movie_id )");
            var result = (context.FirstOrDefault<theater_movie_theater_movie>(sql)).MapTo<theater_movie_theater_movie, TheaterMovieTheaterMovie>();
            return result;
        }

        public Ticket BookTicket(ticket_seat_reservation ticketSeatReservation)
        {
            ticket ticket = new ticket();
            ticket = ticketSeatReservation.MapTo<ticket_seat_reservation, ticket>();
            ShowDetails showDetails = new ShowDetails();
            showDetails = ticket.MapTo<ticket, ShowDetails>();
            var reservedSeats = GetReservedSeats(showDetails);
            bool isFound = reservedSeats.Intersect(ticketSeatReservation.seats).Any();
            if(!isFound)
            {
                context.Insert("ticket", ticket);
                ReserveSeats(ticket.ID, ticketSeatReservation.seats);
                return ticket.MapTo<ticket, Ticket>();

            }
            else
            {
                return ticket.MapTo<ticket, Ticket>();
            }
        }

        public void ReserveSeats(int ticketId, List<string> seats)
        {
            seat_reservation seatReservation = new seat_reservation();
            foreach(var seat in seats)
            {
                seatReservation.seat_number = seat;
                seatReservation.ticket_id = ticketId;
                context.Insert("seat_reservation", seatReservation);
            }
        }

        public List<string> GetReservedSeats(ShowDetails showDetails)
        {
            var sql = PetaPoco.Sql.Builder.Select("seat_reservation.seat_number").From("seat_reservation").InnerJoin("ticket").On("(ticket.ID = seat_reservation.ticket_id) AND (ticket.theater_movie_id = @0) AND (ticket.date_of_booking = @1) AND (ticket.show_id = @2)", showDetails.theater_movie_id,showDetails.date_of_booking,showDetails.show_id);
            return context.Fetch<string>(sql);
        }
        #endregion
    }
}
