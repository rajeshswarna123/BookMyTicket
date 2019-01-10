using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class TheaterMovie
    {
        public int ID { get; set; }

        public int theater_id { get; set; }

        public int movie_id { get; set; }

        public bool isLive { get; set; }
    }
}
