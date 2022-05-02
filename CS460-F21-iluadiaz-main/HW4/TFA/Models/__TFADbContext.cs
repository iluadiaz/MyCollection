using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TFA.Models
{
    public partial class __TFADbContext : DbContext
    {
        public __TFADbContext()
        {
        }

        public __TFADbContext(DbContextOptions<__TFADbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TrackEvent> TrackEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=__TFAConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Athletes)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Athlete_FK_Team");
            });

            modelBuilder.Entity<RaceResult>(entity =>
            {
                entity.HasOne(d => d.Athlete)
                    .WithMany(p => p.RaceResults)
                    .HasForeignKey(d => d.AthleteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RaceResults_FK_Athlete");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.RaceResults)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RaceResult_FK_Classification");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RaceResults)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RaceResult_FK_TrackEvent");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.RaceResults)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RaceResult_FK_Location");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Team_FK_Coach");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
