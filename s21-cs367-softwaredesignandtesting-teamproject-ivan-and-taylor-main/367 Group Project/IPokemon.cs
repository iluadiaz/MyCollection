using System;
using System.Collections.Generic;
//needs update
//just an interface
namespace Pokemon.Info
{
    public interface IPokemon
    {
        void updateStats(string nature);
        string PokemonName{get; set; }
        string Type{get; set; }
        string Nature{get; set; }
        string[] Moves{get; set;}
        string[] StatNames{get; set; }
        Double[] Stats {get; set;}

    }

}

//update diagram;
//consider adding an update pokemon by calling a delete method followed by an add method.