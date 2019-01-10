using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyTickets.Service.Automapper
{
    public static class AutoMapperExtension
    {
        public static List<TDest> MapToCollection<TSource, TDest>(this List<TSource> List)
        {
            return AutoMapperProfile.mapper.Map<List<TSource>, List<TDest>>(List);
        }

        public static TDest MapTo<TSource, TDest>(this TSource SingleTon)
        {
            return AutoMapperProfile.mapper.Map<TSource, TDest>(SingleTon);
        }

        public static TDest MapFrom<TSource, TDest>(this TSource SingleTon)
        {
            return AutoMapperProfile.mapper.Map<TSource, TDest>(SingleTon);
        }
    }
}
