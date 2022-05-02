using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Game.DAL.Abstract;
using Game.Models;

namespace Game.DAL.Concrete
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        // A new version of this file will be available just prior to the exam.  Replace this file with that one.
        private GameDbContext _ctx;
        public CharacterRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Character> GetCharacter(int characterID)
        {
            if (characterID <= 0)
            {
                throw new System.ArgumentException();
            }

            List<Character> chars = new List<Character>();

            var characters = _dbSet.Include(b => b.Level).Include(c => c.Health).Include(d => d.Created).Include(e => e.CharacterAbilities).ThenInclude(e => e.Ability)
                .Include(f => f.CharacterClass).Include(g => g.CharacterWeapons);

            foreach (var Data in characters)
            {
                if (Data.Id == characterID)
                {
                    var newData = new Character();
                    newData.Level = Data.Level;
                    newData.Health = Data.Health;
                    newData.Created = Data.Created;
                    newData.CharacterAbilities = Data.CharacterAbilities;
                    newData.CharacterClass = Data.CharacterClass;
                    newData.CharacterWeapons = Data.CharacterWeapons;
                    newData.Id = Data.Id;


                    chars.Add(Data);

                }
                return chars.OrderBy(a => a.Created).ToList();
            }
            return chars;
        }

        public IEnumerable<Character> GetAllCharacters()
        {

            List<Character> chars = new List<Character>();

            var characters = _ctx.Characters.Include(e => e.CharacterAbilities).Include(g => g.CharacterWeapons)
                .Include(f => f.CharacterClass);
                

            foreach (var Data in characters)
            {
      
                    var newData = new Character();
                    newData.Name = Data.Name;
                    newData.Level = Data.Level;
                    newData.Health = Data.Health;
                    newData.Created = Data.Created;
                    newData.CharacterAbilities = Data.CharacterAbilities;
                    newData.CharacterClass = Data.CharacterClass;
                    newData.CharacterWeapons = Data.CharacterWeapons;
                    newData.CharacterClass.Name = Data.CharacterClass.Name;
                    newData.Id = Data.Id;


                    chars.Add(newData);

            }
            return chars.OrderByDescending(a => a.Level).ToList();//FIX THE DATE
        }

        public IEnumerable<Ability> GetAbilities(int id)
        {
            if (id <= 0)
            {
                throw new System.ArgumentException();
            }
            List<Character> charactersList = new List<Character>();

            var resultData = _dbSet.Include(e => e.CharacterAbilities).ThenInclude(e => e.Ability);

            List<Ability> chars = new List<Ability>();
            List<CharacterAbility> data = new List<CharacterAbility>();

            foreach (var Data in resultData)
            {
                if (Data.Id == id)
                {

                    data = Data.CharacterAbilities.ToList();
                    
                    foreach(var ability in data)
                    {
                        Ability abilites = new Ability();

                        
                        abilites.CharacterAbilities = data;
                        abilites.Name = ability.Ability.Name;
                        abilites.Id = ability.Ability.Id;
                        
                        chars.Add(abilites);
                    }
                }
                
            }
            return chars.OrderBy(a => a.Name).ToList();


          
        }

        //public IEnumerable<Ability> GetMissingAbilities(int id, IEnumerable<Ability> allAbilities)
        //{
        //    if (id <= 0)
        //    {
        //        throw new System.ArgumentException();
        //    }
        //    List<Character> charactersList = new List<Character>();
          
        //    var resultData = _dbSet.Include(e => e.CharacterAbilities).ThenInclude(e => e.Ability);

        //    allAbilities = _ctx.Abilities;
        //        //_dbSet.Include(b => b.Level).Include(c => c.Health).Include(d => d.Created).Include(f => f.CharacterClass)
        //        //.Include(g => g.CharacterWeapons).Include(e => e.CharacterAbilities).ThenInclude(e => e.Ability).ThenInclude(x => x.Id);
        //    List<Ability> chars = new List<Ability>();
        //    List<CharacterAbility> data = new List<CharacterAbility>();
        //    List<Ability> chars2 = allAbilities.ToList();

        //    List<Ability> returnMe = new List<Ability>();
        //    foreach (var Data in resultData)
        //    {
        //        if (Data.Id == id)
        //        {

        //            data = Data.CharacterAbilities.ToList();

        //            foreach (var ability in data)
        //            {
        //                Ability abilites = new Ability();


        //                abilites.CharacterAbilities = data;
        //                abilites.Name = ability.Ability.Name;
        //                abilites.Id = ability.Ability.Id;



        //                chars.Add(abilites);
        //            }
        //        }

        //    }
        //    for (int i = 0; i < allAbilities.Count(); i++)
        //    {
               
        //            if (chars[i].Name != chars2[i].Name)
        //        {
        //            returnMe.Add(chars[i]);
        //        }
           
        //    }
        //    return returnMe.ToList();
        //}

        // There are no tests for this method
        public int LevelUp(int id)
        {
            // your implementation here


            return -1;
        }
    }

}