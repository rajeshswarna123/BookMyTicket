using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class SeatReservation
    {
        public int ID { get; set; }

        public string seat_number { get; set; }

        public int ticket_id { get; set; }

    }
}
