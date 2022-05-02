using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TFA.Models
{
    [Table("Coach")]
    public partial class Coach
    {
        public Coach()
        {
            Teams = new HashSet<Team>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [InverseProperty(nameof(Team.Coach))]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
