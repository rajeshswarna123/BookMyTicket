using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class TheaterShowTime
    {
        public int ID { get; set; }

        public int theater_movie_id { get; set; }

        public int show_id { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}
