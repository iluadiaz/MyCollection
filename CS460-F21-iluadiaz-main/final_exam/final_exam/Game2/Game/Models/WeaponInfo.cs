using System;

namespace Game.Models
{
    /// <summary>
    /// A helper model that holds summary information about a Weapon being held by a Character.
    /// The data model allows a Character to have the same weapon more than once, which is
    /// common in games like this.
    /// 
    /// This class is used to hold just that info.  To be used "in" a viewmodel, but isn't a 
    /// viewmodel itself.
    /// </summary>
    public partial class WeaponInfo
    {
        // Name of the weapon
        public string Name { get; set; }

        // How many of them a Character has
        public int Count { get; set; }
    }
}