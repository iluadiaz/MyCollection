using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;

namespace TFA.DAL.Concrete
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        private __TFADbContext _ctx;

        public CoachRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public int lastId()
        {
            if (!_ctx.Coaches.Any())
            {
                return 1;
            }
            else if (_ctx.Coaches.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.Coaches.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
}
