using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            Athletes = new HashSet<Athlete>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Column("CoachID")]
        public int CoachId { get; set; }

        [ForeignKey(nameof(CoachId))]
        [InverseProperty("Teams")]
        public virtual Coach Coach { get; set; }
        [InverseProperty(nameof(Athlete.Team))]
        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}
