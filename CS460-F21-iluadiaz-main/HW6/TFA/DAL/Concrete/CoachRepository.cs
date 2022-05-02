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
            ctx = _ctx;
        }

    }
}
