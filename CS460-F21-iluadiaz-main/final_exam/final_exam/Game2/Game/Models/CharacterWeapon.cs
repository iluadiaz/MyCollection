using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("CharacterWeapon")]
    public partial class CharacterWeapon
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int Mastery { get; set; }
        [Column("CharacterID")]
        public int CharacterId { get; set; }
        [Column("WeaponID")]
        public int WeaponId { get; set; }

        [ForeignKey(nameof(CharacterId))]
        [InverseProperty("CharacterWeapons")]
        public virtual Character Character { get; set; }
        [ForeignKey(nameof(WeaponId))]
        [InverseProperty("CharacterWeapons")]
        public virtual Weapon Weapon { get; set; }
    }
}
