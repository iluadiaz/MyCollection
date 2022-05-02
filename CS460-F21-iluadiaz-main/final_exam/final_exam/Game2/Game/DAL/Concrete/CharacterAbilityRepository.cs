using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.DAL.Concrete
{
    public class CharacterAbilityRepository : Repository<CharacterAbility>, ICharacterAbilityRepository
    {
        private GameDbContext _ctx;
        public CharacterAbilityRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
