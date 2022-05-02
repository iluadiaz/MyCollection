using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("TrackEvent")]
    public partial class TrackEvent
    {
        public TrackEvent()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [InverseProperty(nameof(RaceResult.Event))]
        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
