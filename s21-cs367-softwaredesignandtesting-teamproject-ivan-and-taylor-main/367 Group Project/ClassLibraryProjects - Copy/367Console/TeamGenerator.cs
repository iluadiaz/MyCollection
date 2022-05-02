using System;
using System.Collections.Generic;
using System.IO;

namespace Pokemon.Info
{
    public class TeamGenerator 
    {   
        public string[] Natures { get; set; }
        public string[] PokemonNames { get; set; }
        public string[] Stats { get; set; }
        public PokemonManager Pokemon{get; set; }
        public TeamGenerator()
        {
            Natures = File.ReadAllLines("Natures.txt");
            PokemonNames = File.ReadAllLines("PokemonList.txt");
            Stats = File.ReadAllLines("Pokemonstats.txt");
            Pokemon = GetRandomPokemon();
        }
        public string GetRandomNature()
        {
            Random rnd2 = new Random();
            string nature = Natures[rnd2.Next(0, 25)];
            return nature;
        }
        public string GetRandomName()
        {
            Random rnd = new Random();
            string name = PokemonNames[rnd.Next(0, 110)];
            return name;
        }

        public string[] GetStatsForName(string name)
        {
            int index = Array.IndexOf(PokemonNames, name);
            string stats = Stats[index];
            string[] listofstats = stats.Split("\t");
            return listofstats;
        }
        public PokemonManager GetRandomPokemon()
        {
            string name = GetRandomName();
            string nature = GetRandomNature();
            string[] stats = GetStatsForName(name);
            PokemonManager pokemon = new PokemonManager(name, nature, stats);
            return pokemon;    
        }
    }
} 