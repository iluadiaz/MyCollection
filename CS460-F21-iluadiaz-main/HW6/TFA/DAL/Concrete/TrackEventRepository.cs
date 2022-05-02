using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;

namespace TFA.DAL.Concrete
{
    public class TrackEventRepository : Repository<TrackEvent>, ITrackEventRepository
    {
        private __TFADbContext _ctx;
        public TrackEventRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
