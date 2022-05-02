using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("RaceResult")]
    public partial class RaceResult
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public double Time { get; set; }
        [Column("AthleteID")]
        public int AthleteId { get; set; }
        [Column("ClassificationID")]
        public int ClassificationId { get; set; }
        [Column("LocationID")]
        public int LocationId { get; set; }
        [Column("EventID")]
        public int EventId { get; set; }

        [ForeignKey(nameof(AthleteId))]
        [InverseProperty("RaceResults")]
        public virtual Athlete Athlete { get; set; }
        [ForeignKey(nameof(ClassificationId))]
        [InverseProperty("RaceResults")]
        public virtual Classification Classification { get; set; }
        [ForeignKey(nameof(EventId))]
        [InverseProperty(nameof(TrackEvent.RaceResults))]
        public virtual TrackEvent Event { get; set; }
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("RaceResults")]
        public virtual Location Location { get; set; }
    }
}
