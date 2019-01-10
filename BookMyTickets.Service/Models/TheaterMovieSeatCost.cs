using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class TheaterMovieSeatCost
    {

        public int ID { get; set; }

        
        public int price { get; set; }
        
        
        public int seats_in_row { get; set; }
        

        public int total_rows { get; set; }

    }
}
