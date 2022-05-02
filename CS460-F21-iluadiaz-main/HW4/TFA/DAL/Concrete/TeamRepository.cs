using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace TFA.DAL.Concrete
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private __TFADbContext _ctx;
        public TeamRepository(__TFADbContext ctx) : base(ctx)
        {
           _ctx = ctx;
        }
        public int lastId()
        {
            if (!_ctx.Teams.Any())
            {
                return 1;
            }
            else if(_ctx.Teams.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.Teams.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
}

