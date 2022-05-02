using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon.Info
{
    public class PokemonManager : IPokemon
    {    
        public PokemonManager(string pokemonName, string nature, string[] stats)
        {
            for (int i = 0; i < stats.Length; i++)
            {
                Stats[i] = double.Parse(stats[i]);
            }

            PokemonName = pokemonName;
            Nature = nature;
            
            UpdateStats();

            HitPoints = Stats[0];
            Attack = Stats[1];
            Defense = Stats[2];
            SpecialAttack = Stats[3];
            SpecialDefense = Stats[4];
            Speed = Stats[5];

            StatNames[0] = "hp";
            StatNames[1] = "atk";
            StatNames[2] = "def";
            StatNames[3] = "spa";
            StatNames[4] = "spd";
            StatNames[5] = "spe";
        }
        public void UpdateStats()
        {
            if(Nature == "Hardy"|| Nature == "Docile"|| Nature == "Serious"|| Nature == "Bashful"|| Nature == "Quirky"  )
            {
                Console.WriteLine("That Nature does not effect the stats of a pokemon.");
            }
            else if(Nature == "Lonely")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));

            }
               else if(Nature == "Brave")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));

            }
               else if(Nature == "Adamant")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));

            }
               else if(Nature == "Naughty")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));

            }
               else if(Nature == "Bold")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
                else if(Nature == "Relaxed")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(Nature == "Impish")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
            else if(Nature == "Lax")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(Nature == "Timid")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(Nature == "Hasty")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(Nature == "Jolly")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
            else if(Nature == "Naive")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(Nature == "Modest")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(Nature == "Mild")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(Nature == "Quiet")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(Nature == "Rash")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(Nature == "Calm")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(Nature == "Gentle")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(Nature == "Sassy")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(Nature == "Careful")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
        }
        public string PokemonName{get; set; }
        public string Nature{get; set; }
        public string[] StatNames{get; set; } = new string[6];
        public double[] Stats {get; set;} = new double[6];
        public double HitPoints { get; set;}
        public double Attack { get; set;}
        public double Defense { get; set;}
        public double SpecialAttack { get; set; }
        public double SpecialDefense { get; set; }
        public double Speed { get; set; } 
        public string PokemonUse { get; set; }  

    }
}

//update artifacts!!