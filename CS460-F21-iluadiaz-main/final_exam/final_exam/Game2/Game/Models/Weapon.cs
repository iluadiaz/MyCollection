using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("Weapon")]
    public partial class Weapon
    {
        public Weapon()
        {
            CharacterWeapons = new HashSet<CharacterWeapon>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(CharacterWeapon.Weapon))]
        public virtual ICollection<CharacterWeapon> CharacterWeapons { get; set; }
    }
}
