using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game.Models;
using Game.DAL.Abstract;
using Game.ViewModels;

namespace Game.Controllers
{
    public class CharacterController : Controller
    {

        private readonly ICharacterRepository _characterRepo;
        private readonly GameDbContext ctx;
        private readonly ILogger<HomeController> _logger;

        public CharacterController(ICharacterRepository characterRepo, GameDbContext _ctx, ILogger<HomeController> logger)
        {
            _characterRepo = characterRepo;
            ctx = _ctx;
            _logger = logger;
        }

        // Use the starter Index.cshtml page
        public IActionResult Index()
        {
            // just so it will complile/run, replace with your implementation
            IEnumerable<Character> characters = new List<Character>();

          
            CharacterViewModel data = new CharacterViewModel();

            characters = _characterRepo.GetAllCharacters().ToList();

            //foreach (adventurer in _characterRepo.GetAllCharacters())
            //{
            //    Character x = new Character();

            //    x = Characters;
            //    characters = _characterRepo.GetCharacter()
            //}

            return View(characters);
        }

        // Use the starter Details.cshtml page
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
            data.abilityList = _characterRepo.GetAbilities(id2).ToList();
            data.selectedCharacter = data.getSelectedCharacter(id2, data.characterList);
            
            //data.abilityList = characters.
            return View(data);
        }

        [HttpPost]
        public JsonResult LevelUp(int? id)
        {
            int cid = id.Value;
            if (id == null || !_characterRepo.Exists(cid))
            {
                return Json(new { Error = "id is not valid" });
            }
            // your implementation here



            return Json(new { Level = 1 }); // just so it will run until implemented
        }
    }
}