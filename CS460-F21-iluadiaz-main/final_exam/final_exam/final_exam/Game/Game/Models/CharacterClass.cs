using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Game.Models
{
    [Table("CharacterClass")]
    public partial class CharacterClass
    {
        public CharacterClass()
        {
            Characters = new HashSet<Character>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty(nameof(Character.CharacterClass))]
        public virtual ICollection<Character> Characters { get; set; }
    }
}
