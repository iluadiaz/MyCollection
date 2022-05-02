using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.DAL.Abstract
{
    public interface ICharacterRepository : IRepository<Character>
    {
        /// <summary>
        /// Get summary weapons information for the given Character.  This produces a distinct
        /// list of weapons (no duplicates), and where there were duplicates the weapon's count 
        /// has been incremented accordingly.  
        /// </summary>
        /// <param name="id">PK id of the Character to get the weapons info for</param>
        /// <returns>Distinct list of summary info about each weapon, sorted by weapon name</returns>
        IEnumerable<WeaponInfo> GetWeaponsInfo(int id);
        public IEnumerable<Character> GetAllCharacters();
    }
}