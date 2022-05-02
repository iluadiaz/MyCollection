using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game.Models;
using Game.DAL.Abstract;
using Game.ViewModels;

namespace Game.Controllers
{
    public class CharacterController : Controller
    {

        private readonly ICharacterRepository _characterRepo;
        private readonly IRepository<Ability> _abilityRepo;
        private readonly IRepository<Weapon> _weaponRepo;
        private readonly IGameService _gameService;

        public CharacterController(ICharacterRepository characterRepo, 
                                   IRepository<Ability> abilityRepo, 
                                   IRepository<Weapon> weaponRepo,
                                   IGameService gameService)
        {
            _characterRepo = characterRepo;
            _abilityRepo = abilityRepo;
            _weaponRepo = weaponRepo;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            // just so it will complile/run, replace with your implementation
            IEnumerable<Character> characters = new List<Character>();


            CharacterViewModel data = new CharacterViewModel();

            characters = _characterRepo.GetAllCharacters().ToList();


            return View(characters);
        }


        public IActionResult Details(int? id)
        {
            int cid = id.Value;
            if (id == null || !_characterRepo.Exists(cid))
            {
                return View(null);
            }
            // Your implementation here

            int id2 = id ?? default(int);

            IEnumerable<Character> characters = new List<Character>();

            CharacterViewModel data = new CharacterViewModel();

            data.characterList = _characterRepo.GetAllCharacters().ToList();
            //getweaponshere
            data.selectedCharacter = data.getSelectedCharacter(id2, data.characterList);

            //data.abilityList = characters.
            return View(data);
        }

        // AJAX method, returns weapons summary info.  Uses the character repository
        // This method is finished, use it as it is
        [HttpGet]
        public JsonResult Weapons(int? id)
        {
            
            if(id == null || !_characterRepo.Exists(id.Value))
            {
                return Json(new { Success = false, Error = "id is not valid"});
            }
            var weapons = _characterRepo.GetWeaponsInfo(id.Value);
            return Json(weapons);
        }

        // AJAX method: give the character a weapon.  Uses the GameService to do this.
        // This method is finished, use it as it is
        [HttpPost]
        public JsonResult AddWeapon(int? characterId, int? weaponId)
        {
            
            if(characterId == null || !_characterRepo.Exists(characterId.Value) ||
               weaponId == null || !_weaponRepo.Exists(weaponId.Value))
            {
                return Json(new { Success = false, Error = "one or both of the id's are not valid"});
            }
            int cid = characterId.Value;
            int wid = weaponId.Value;
            _gameService.AddWeapon(cid, wid, 0);
            return Json(new { Success = true });
        }
    }
}
