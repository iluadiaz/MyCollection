using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("Ability")]
    public partial class Ability
    {
        public Ability()
        {
            CharacterAbilities = new HashSet<CharacterAbility>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Cooldown { get; set; }

        [InverseProperty(nameof(CharacterAbility.Ability))]
        public virtual ICollection<CharacterAbility> CharacterAbilities { get; set; }
    }
}
