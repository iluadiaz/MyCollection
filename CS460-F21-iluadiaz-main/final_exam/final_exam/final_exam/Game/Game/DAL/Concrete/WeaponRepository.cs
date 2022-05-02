using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.DAL.Concrete
{
    public class WeaponRepository : Repository<Weapon>, IWeaponRepository
    {
        private GameDbContext _ctx;
        public WeaponRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
