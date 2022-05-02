using System;
using System.Collections.Generic;

namespace Pokemon.Info
{
    public class PokemonUse
    {
        public string pokemonUse {get; set; } 
        public PokemonUse(PokemonManager pokemonName)
        {
            pokemonUse = PokemonRoleAssign(pokemonName);
        }
        public string PokemonRoleAssign(PokemonManager pokemonName)
        {     
            double[] newArray = new double[5];
            for (int i = 0; i < 5; i++)
            {
                newArray[i] = pokemonName.Stats[i+1];
            }         
            double atk = newArray[0];
            double def = newArray[1];
            double spa = newArray[2];
            double spd = newArray[3];
            double spe = newArray[4];

            Array.Sort(newArray);

            double temp = newArray[4];
            double temp2 = newArray[3];
  
            if(temp == spd && temp == atk && temp == def && temp == spe && temp == spa)
            {
                return "This pokemon can serve any role ";
            }

            else if( spa == atk && spa == temp || atk == spa && spa == temp2 ||  atk == spa && atk == temp2 )
            {   
                return "This pokemon can be either a special or physical sweeper ";
            }

            else if((temp == spe && temp2 == atk) || (temp == atk && temp2 == spe) || (spe == atk && atk != spa))
            {
                return "This pokemon will serve best as a fast physical sweeper ";
            }

            else if((temp == spe && temp2 == spa) || (temp == spa && temp2 == spe) || (temp == spe && temp == spa))
            {
                return "This pokemon will serve best as a fast special sweeper ";
            }

            else if(temp == atk && temp2 != spe )
            {
                return "This pokemon will serve best as a physical sweeper ";
            }

            else if(temp == spa && temp2 != spe)
            {
                return "This pokemon will serve best as a special sweeper";
            }

            else if((temp == def  && temp2 == spd) || (temp == spd && temp2 == def) && spd==def)
            {
                return "This pokemon will serve best as a damage soak";
            }

            else if(temp == def )
            {
               return "This pokemon will serve best as a physical damage soak ";
            }

            else if(temp == spd )
            {
                return "This pokemon will serve best as a special damage soak ";
            }
            else
            return "Pokemon is not optimized!";
        }
    }
}
