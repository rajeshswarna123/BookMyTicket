using BookMyTickets.Service.Models;
using BookMyTicketConnectionString;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyTickets.Service.Automapper
{
    public static class AutoMapperProfile 
    {
           static MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ticket, Ticket>();
                cfg.CreateMap<movie, Movie>();
                cfg.CreateMap<theater, Theater>();
                cfg.CreateMap<seat_cost, SeatCost>();
                cfg.CreateMap<seat_reservation, SeatReservation>();
                cfg.CreateMap<theater_show_time, TheaterShowTime>();
                cfg.CreateMap<theater_movie_theater, TheaterMovieTheater>();
                cfg.CreateMap<theater_show_time_show, TheaterShowTimeShow>();
                cfg.CreateMap<theater_movie_seat_cost, TheaterMovieSeatCost>();
                cfg.CreateMap<theater_movie_theater_movie, TheaterMovieTheaterMovie>();
                cfg.CreateMap<ticket_seat_reservation, TicketSeatReservation>();
                cfg.CreateMap<ticket_seat_reservation, ticket>();
            });
            
        public static IMapper mapper = config.CreateMapper();
    }
}