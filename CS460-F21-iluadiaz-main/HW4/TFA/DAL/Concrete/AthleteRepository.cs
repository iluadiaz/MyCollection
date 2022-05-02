using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using Microsoft.AspNetCore.Hosting;
using FileHelpers;

namespace TFA.DAL.Concrete
{
    public class AthleteRepository : Repository<Athlete>, IAthleteRepository
    {
        private __TFADbContext _ctx;
        public AthleteRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        
        public int lastId()
        {
            if (!_ctx.Athletes.Any())
            {
                return 1;
            }
            else if (_ctx.Athletes.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.Athletes.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
} 
