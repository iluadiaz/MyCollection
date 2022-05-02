using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game.Models;
using Game.DAL.Abstract;
using Game.DAL.Concrete;

namespace Game.ViewModels
{
    public class CharacterViewModel
    {
        public List<Character> characterList = null;

        public List<Ability> abilityList = null;

        public Character selectedCharacter = null;

        public Character getSelectedCharacter(int? id, IEnumerable<Character> characterList)
        {
            if (id == null)
            {
                return null;
            }

            Character character = new Character();

        int id2 = id ?? default(int);
            foreach (var x in characterList)
            {
                if (x.Id == id2)
                {
                    character.Name = x.Name;
                    character.Level = x.Level;
                    character.Health = x.Health;
                    character.CharacterClass = x.CharacterClass;
                    character.CharacterClass.Name = x.CharacterClass.Name;
                    character.CharacterWeapons = x.CharacterWeapons;
                }
            }
            return character;
        }

       
    }
}
