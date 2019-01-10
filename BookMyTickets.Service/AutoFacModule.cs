using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookMyTicketConnectionString;

namespace BookMyTickets.Service
{
    public class AutoFacModule :Module
    {
        private string __ConnectionString;

        public AutoFacModule(string ConnectionString)
        {
            __ConnectionString = ConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OnlineMovieTicketBookingService>().As<IOnlineMovieTicketBookingService>();
            builder.Register(c => new BookMyTicketConnectionStringDB(__ConnectionString));
            base.Load(builder);
        }
    }
}
