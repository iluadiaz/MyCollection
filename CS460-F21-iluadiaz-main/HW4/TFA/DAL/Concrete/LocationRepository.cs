using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;

namespace TFA.DAL.Concrete
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private __TFADbContext _ctx;
        public LocationRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public int lastId()
        {
            if (!_ctx.Locations.Any())
            {
                return 1;
            }
            else if(_ctx.Locations.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.Locations.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
}
