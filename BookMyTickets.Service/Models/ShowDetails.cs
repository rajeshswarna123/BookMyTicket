using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class ShowDetails
    {
        public int theater_movie_id { get; set; }

        public  DateTime date_of_booking { get; set; }

        public int show_id { get; set; }
    }
}
