using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.DAL.Concrete
{
    public class CharacterWeaponRepository : Repository<CharacterWeapon>, ICharacterWeaponRepository
    {
        private GameDbContext _ctx;
        public CharacterWeaponRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
