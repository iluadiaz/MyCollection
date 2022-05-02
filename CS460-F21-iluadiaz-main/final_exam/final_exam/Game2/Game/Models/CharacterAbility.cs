using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("CharacterAbility")]
    public partial class CharacterAbility
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AssignDate { get; set; }
        [Column("CharacterID")]
        public int CharacterId { get; set; }
        [Column("AbilityID")]
        public int AbilityId { get; set; }

        [ForeignKey(nameof(AbilityId))]
        [InverseProperty("CharacterAbilities")]
        public virtual Ability Ability { get; set; }
        [ForeignKey(nameof(CharacterId))]
        [InverseProperty("CharacterAbilities")]
        public virtual Character Character { get; set; }
    }
}
