using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyTickets.Service.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int theater_movie_id { get; set; }

        public DateTime date_of_booking { get; set; }

        public int show_id { get; set; }

        public int seat_cost { get; set; }

        public int seats_count { get; set; }

        public int total_amount { get; set; }

    }
}