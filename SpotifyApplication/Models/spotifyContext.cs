using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpotifyApplication.Models
{
    public partial class spotifyContext : DbContext
    {
        public spotifyContext()
        {
        }

        public spotifyContext(DbContextOptions<spotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<ArtistsSong> ArtistsSongs { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRating> UserRatings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Bio)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtistsSong>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Artists_Songs");

                entity.HasOne(d => d.Artist)
                    .WithMany()
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Artists_S__Artis__15502E78");

                entity.HasOne(d => d.Song)
                    .WithMany()
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK__Artists_S__SongI__164452B1");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.CoverImage)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRating>(entity =>
            {
                entity.HasOne(d => d.Song)
                    .WithMany(p => p.UserRatings)
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK__UserRatin__SongI__1A14E395");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRatings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRatin__UserI__1920BF5C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
