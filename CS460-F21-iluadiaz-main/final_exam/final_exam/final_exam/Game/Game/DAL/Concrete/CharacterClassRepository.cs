using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.DAL.Concrete
{
    public class CharacterClassRepository : Repository<CharacterClass>, ICharacterClassRepository
    {
        private GameDbContext _ctx;
        public CharacterClassRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
