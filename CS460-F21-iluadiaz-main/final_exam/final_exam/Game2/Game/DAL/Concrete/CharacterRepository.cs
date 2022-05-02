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
        private GameDbContext _ctx;
        public CharacterRepository(GameDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<WeaponInfo> GetWeaponsInfo(int id)
        {
            if(!Exists(id))
            {
                return new List<WeaponInfo>();
            }

            // So it will compile, replace with your own implementation
            List<WeaponInfo> weaponInfoList = new List<WeaponInfo>();
            List<WeaponInfo> weaponInfoList2 = new List<WeaponInfo>();
            //IEnumerable<WeaponInfo> duplicates = 
                //int counts = weaponInfoList2.GroupBy(a => a.Name).Sum(b => b.Count() - 1);

            var resultData = _dbSet.Include(a => a.CharacterWeapons).ThenInclude(a => a.Weapon);

            
            

            List<CharacterWeapon> charWeaps = new List<CharacterWeapon>();
            List<Weapon> weapons = new List<Weapon>();

            WeaponInfo a = new WeaponInfo();
            Weapon weap = new Weapon();
            
            int lengthCheck = 1;
            string name = null;
            foreach (var Data in resultData)
            {
                
                if (Data.Id == id)
                {

                    charWeaps = Data.CharacterWeapons.ToList();

                    foreach (var weapon in charWeaps)
                    {
                        WeaponInfo h = new WeaponInfo();
                        weap.Name = weapon.Weapon.Name;
                        
                        weapons.Add(weap);
                        h.Name = weapon.Weapon.Name;
                        h.Count = 1;
                        //weaponInfoList2.Add(h);
                    }
                }

            }

            //for(int i = 0; i < weaponInfoList2.Count(); i++)
            //{

            //    for(int j = i + 1; j < weaponInfoList.Count(); j++)
            //    {
            //        if(weaponInfoList2[i].Name == weaponInfoList2[j].Name)
            //        {
            //            weaponInfoList2[j].Count++;
            //        }
            //    }
            //}


            weapons.OrderBy(a => a.Name);
            var list = resultData.ToList();

            for (int i = 0; i < weapons.Count(); i++)
            {
                a.Name = weapons[i].Name;
                if (a.Name == weapons[i].Name)
                {
                    a.Count++;

                }
                else a.Count = 1;
                

                     if(a.Name != weapons[i].Name || i == weapons.Count()-1)
                    {
                        weaponInfoList.Add(a);
                    
                    }
                
                    //i++;
                
            }
            //int listSize = weapons.Count();
            //string lastname = null;
            //foreach (var weaps in weapons)
            //{
            //    a.Name = weaps.Name;
            //    if(a.Name != weaps.Name)
            //    {
            //        weaponInfoList.Add(a);

            //    }
            //    if (a.Name == weaps.Name)
            //    {
            //        a.Count++;
            //    }
            //    lastname = a.Name;

            //}

            //int infoSize = weaponInfoList.Count();
            //weapons.OrderBy(a => a.Name);
            //int listSize = weapons.Count();
            //foreach(var weapon in weapons)
            //{
            //    //if (a.Count == 0 )
            //    //{
            //        name = weapon.Name;
            //        a.Name = weapon.Name;
            //        a.Count++;
            //    //}
            //    //if (name == weapon.Name)
            //    //{
            //    //    a.Count++;
            //    //    lengthCheck++;
            //    //}
            //    name = weapon.Name;

            //    //a.Count = weaponCounter;
            //    //weaponCounter++;
            //    if (name != weapon.Name && lengthCheck >= listSize  )
            //    {
            //        weaponInfoList.Add(a);

            //    }

            //}
            return weaponInfoList.ToList();
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
            return chars.OrderByDescending(a => a.CharacterWeapons.Count()).ToList();
        }

    }
}