using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.DAL.Abstract
{
    public interface IGameService
    {
        /// <summary>
        /// Give a Weapon to a Character
        /// </summary>
        /// <param name="characterId">PK id of the Character</param>
        /// <param name="weaponId">PK id of the Weapon</param>
        /// <param name="mastery">Mastery level for this character and weapon</param>
        void AddWeapon(int characterId, int weaponId, int mastery = 0);
    }
}