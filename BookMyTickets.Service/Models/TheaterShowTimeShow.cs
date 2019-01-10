using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class TheaterShowTimeShow
    {

        public int ID { get; set; }

        public DateTime show_time { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

    }
}
