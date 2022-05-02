using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.DAL.Abstract;
using Game.Models;

namespace Game.DAL.Concrete
{
    public class AbilityRepository : Repository<Ability>, IAbilityRepository
    {
        private GameDbContext _ctx;
        public AbilityRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
