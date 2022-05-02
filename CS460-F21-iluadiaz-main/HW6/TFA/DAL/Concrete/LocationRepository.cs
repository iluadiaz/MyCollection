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
    }
}
