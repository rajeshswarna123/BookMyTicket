using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public int Duration_Minutes { get; set; }
    }
}
