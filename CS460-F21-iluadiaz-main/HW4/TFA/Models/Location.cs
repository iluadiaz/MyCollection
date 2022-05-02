using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime MeetDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [InverseProperty(nameof(RaceResult.Location))]
        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
