using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("Character")]
    public partial class Character
    {
        public Character()
        {
            CharacterAbilities = new HashSet<CharacterAbility>();
            CharacterWeapons = new HashSet<CharacterWeapon>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        [Column("CharacterClassID")]
        public int CharacterClassId { get; set; }

        [ForeignKey(nameof(CharacterClassId))]
        [InverseProperty("Characters")]
        public virtual CharacterClass CharacterClass { get; set; }
        [InverseProperty(nameof(CharacterAbility.Character))]
        public virtual ICollection<CharacterAbility> CharacterAbilities { get; set; }
        [InverseProperty(nameof(CharacterWeapon.Character))]
        public virtual ICollection<CharacterWeapon> CharacterWeapons { get; set; }

        public string date { get => Created.ToString("MM/dd/yyyy"); } 
    }
}
