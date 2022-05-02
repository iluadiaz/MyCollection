using System;
using System.Collections.Generic;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.DAL.Concrete
{
    public class GameService : IGameService
    {
        // Repositories needed to perform the task
        private IRepository<Character> _characterRepository;
        private IRepository<Weapon> _weaponRepository;
        private IRepository<CharacterWeapon> _characterWeaponRepository;


        public GameService(IRepository<Character> characterRepo, IRepository<Weapon> weaponRepo, IRepository<CharacterWeapon> characterWeaponRepo)
        {
            _characterRepository = characterRepo;
            _weaponRepository = weaponRepo;
            _characterWeaponRepository = characterWeaponRepo;
        }

        public void AddWeapon(int characterId, int weaponId, int mastery = 0)
        {

            Weapon weapons = _weaponRepository.FindById(weaponId);

            var w = _characterWeaponRepository.FindById(weaponId);
            
            //foreach(var weap in w)
            //{

            //}

            var character = _characterRepository.FindById(characterId);

            //character.CharacterWeapons.Add(weapons);
            
            return;
        }
    }
}