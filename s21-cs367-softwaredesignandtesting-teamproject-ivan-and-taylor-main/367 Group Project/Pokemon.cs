using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon.Info
{
    public class PokemonManager : IPokemon
    {
        //Creates Pokemon manager. 
        public PokemonManager(string pokemonName, string type, string nature)
        {

            PokemonName = pokemonName;

            Type = type;

            Nature = nature;

            StatNames[0] = "hp";
            StatNames[1] = "atk";
            StatNames[2] = "def";
            StatNames[3] = "spa";
            StatNames[4] = "spd";
            StatNames[5] = "spe";
        }

        //Updates stats of pokemon based on nature
        public void updateStats(string nature)
        {
            if(nature == "Hardy"|| nature == "Docile"|| nature == "Serious"|| nature == "Bashful"|| nature == "Quirky"  )
            {
                Console.WriteLine("That nature does not effect the stats of a pokemon.");
            }
            else if(nature == "Lonely")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));

            }
               else if(nature == "Brave")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));

            }
               else if(nature == "Adamant")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));

            }
               else if(nature == "Naughty")
            {
                Stats[1] = Stats[1] + Math.Floor((Stats[1]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));

            }
               else if(nature == "Bold")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
                else if(nature == "Relaxed")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(nature == "Impish")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
            else if(nature == "Lax")
            {
                Stats[2] = Stats[2] + Math.Floor((Stats[2]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(nature == "Timid")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(nature == "Hasty")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(nature == "Jolly")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
            else if(nature == "Naive")
            {
                Stats[5] = Stats[5] + Math.Floor((Stats[5]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(nature == "Modest")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(nature == "Mild")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(nature == "Quiet")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(nature == "Rash")
            {
                Stats[3] = Stats[3] + Math.Floor((Stats[3]/10));
                Stats[4] = Stats[4] - Math.Floor((Stats[4]/10));
            }
            else if(nature == "Calm")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[1] = Stats[1] - Math.Floor((Stats[1]/10));
            }
            else if(nature == "Gentle")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[2] = Stats[2] - Math.Floor((Stats[2]/10));
            }
            else if(nature == "Sassy")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[5] = Stats[5] - Math.Floor((Stats[5]/10));
            }
            else if(nature == "Careful")
            {
                Stats[4] = Stats[4] + Math.Floor((Stats[4]/10));
                Stats[3] = Stats[3] - Math.Floor((Stats[3]/10));
            }
        }

        public string PokemonName{get; set; }
        public string Type{get; set; }
        public string Nature{get; set; }
        public string[] Moves{get; set;} = new string[4];
        public string[] StatNames{get; set; } = new string[6];
        public double[] Stats {get; set;} = new double[6];

    }

}

//update artifacts!!