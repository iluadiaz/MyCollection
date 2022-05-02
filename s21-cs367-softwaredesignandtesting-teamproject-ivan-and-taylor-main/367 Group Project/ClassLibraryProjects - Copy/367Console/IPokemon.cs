using System;
using System.Collections.Generic;
namespace Pokemon.Info
{
    public interface IPokemon
    {
        string PokemonName{get; set; }
        string Nature{get; set; }
        string[] StatNames{get; set; }
        Double[] Stats {get; set;}
        double HitPoints { get; set;}
        double Attack { get; set;}
        double Defense { get; set;}
        double SpecialAttack { get; set; }
        double SpecialDefense { get; set; }
        double Speed  { get; set; } 
        string PokemonUse { get; set;}

    }
}
