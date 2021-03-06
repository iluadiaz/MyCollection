using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;

namespace TFA.DAL.Concrete
{
    public class RaceResultRepository : Repository<RaceResult>, IRaceResultRepository
    {
        private __TFADbContext _ctx;
        public RaceResultRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public int lastId()
        {
            if (!_ctx.RaceResults.Any())
            {
                return 1;
            }
            else if(_ctx.RaceResults.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.RaceResults.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
}
