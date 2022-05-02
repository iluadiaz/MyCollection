using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("Athlete")]
    public partial class Athlete
    {
        public Athlete()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string FullName { get; set; }
        [Column("TeamID")]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("Athletes")]
        public virtual Team Team { get; set; }
        [InverseProperty(nameof(RaceResult.Athlete))]
        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
