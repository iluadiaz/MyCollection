using System;
using Pokemon.Info;
using System.Collections.Generic;
using System.Linq;

namespace _367Project
{
    class Program 
    {
        static void Main(string[] args)
        {
            //List to store Pokemons, new lists = new teams;
            IList<PokemonManager> mons = new List<PokemonManager>();

            Console.WriteLine("Please provide the Pokemon name, type and nature.");
            
            //For loop to manaually create a team
            for(int i = 0; i < 2; i++)
            {
                string pokemon = Console.ReadLine(), type = Console.ReadLine(), nature = Console.ReadLine();

                PokemonManager mon = new PokemonManager(pokemon, type, nature);

                mons.Add(mon);

            }

            //int a = 1 is a bandaid fix, this will change
            int a = 1;
            Console.WriteLine("In this order type in your pokemon's Health, Attack, Defense, Special Attack, Special Defense, and Speed.");
            //might need to add a case that asks for the pokemons current stats and nature.
            //more for loops for manual tracking of pokemon stats
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("Stats for pokemon: " + i+a);
                for(int j = 0; j < 6; j++)
                {
                var statVal = Console.ReadLine();
                mons[i].Stats[j] = Convert.ToInt32(statVal);
                }
            }
            Console.WriteLine("Pokemon stats are as follows: ");

            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("Stats for pokemon: " + i);
                for(int j = 0; j < 6; j++)
                {
            Console.Write(mons[i].StatNames[j] + ": " + mons[i].Stats[j] + " ");
            Console.WriteLine();
                }
            }

            Console.WriteLine();

            //Tests to see if update stats works by updating only one set of stats 
            mons[1].updateStats(mons[1].Nature);

            Console.WriteLine("Pokemon stats after applying nature change are as follows: ");

            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("Stats for pokemon: " + i);
                for(int j = 0; j < 6; j++)
                {
                    Console.Write(mons[i].StatNames[j] + ": " + mons[i].Stats[j] + " ");
                }
          
            Console.WriteLine();
            }

            Console.WriteLine("WARNING, IF YOU ENTER YOUR POKEMONS CURRENT NATURE, YOU WILL RECIEVE A SECOND STAT CHANGE. ");
            Console.WriteLine("EX: A POKEMON WITH ADAMANT NATURE HAS 220 ATTACK AND 180 SPECIAL ATTACK WILL GET 242 ATTACK AND 162 SPECIAL ATTACK");
            Console.WriteLine("THIS MEANS A STAT CHANGE OF 20% OCCURS SINCE THE BASE STATS ARE 200 ATTACK 200 SPECIAL ATTACK (10% CHANGE * 2).");

            Console.WriteLine("The pokemon on your team are: " );

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(mons[i].PokemonName);
            }
        }
    }
}
