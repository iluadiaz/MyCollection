using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Game.Models
{
    public partial class GameDbContext : DbContext
    {
        public GameDbContext()
        {
        }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterAbility> CharacterAbilities { get; set; }
        public virtual DbSet<CharacterClass> CharacterClasses { get; set; }
        public virtual DbSet<CharacterWeapon> CharacterWeapons { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=GameConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasOne(d => d.CharacterClass)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.CharacterClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Character_CClass_ID");
            });

            modelBuilder.Entity<CharacterAbility>(entity =>
            {
                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.CharacterAbilities)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CAbility_Ability_ID");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterAbilities)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CAbility_Character_ID");
            });

            modelBuilder.Entity<CharacterWeapon>(entity =>
            {
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterWeapons)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CWeapon_Character_ID");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.CharacterWeapons)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CWeapon_Weapon_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
