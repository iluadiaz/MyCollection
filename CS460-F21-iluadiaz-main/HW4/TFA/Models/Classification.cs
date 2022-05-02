using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("Classification")]
    public partial class Classification
    {
        public Classification()
        {
            RaceResults = new HashSet<RaceResult>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [InverseProperty(nameof(RaceResult.Classification))]
        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}
