using System;
using ExamWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExamWork.DataAccess
{
    public class artistContext : DbContext
    {
        public artistContext()
        {
         //Database.EnsureDeleted();
        //   Database.EnsureCreated();
        }

        public artistContext(DbContextOptions<artistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Album_Song> Album_Songs { get; set; }
        public virtual DbSet<Group> Groups{ get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server_connection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {


                entity.HasKey(e => e.Album_id);

                entity.Property(e => e.Album_id)
                    .HasColumnName("Album_id");

                entity.Property(e => e.Artist_id)
                    .HasColumnName("Artist_id");

                entity.Property(e => e.Album_year)
                    .HasColumnName("Album_year");

                entity.Property(e => e.Album_tracks)
                    .HasColumnName("Album_tracks");
               
                entity.HasOne(d => d.Artists)
                    .WithMany()
                    .HasForeignKey(d => d.Artist_id);
            });
            modelBuilder.Entity<Album_Song>(entity =>
            {
                entity.HasKey(e => new { e.Album_id ,e.Song_id });

                entity.Property(e => e.Album_id)
                    .HasColumnName("Album_id");

                entity.Property(e => e.Song_id)
                    .HasColumnName("Song_id");

                entity.Property(e => e.Track_number)
                    .HasColumnName("Track_number");

                entity.HasOne(d => d.Albums)
                   .WithMany()
                   .HasForeignKey(d => d.Album_id);

                entity.HasOne(d => d.Songs)
                   .WithMany()
                   .HasForeignKey(d => d.Song_id);
            });
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Artist_id);

                entity.Property(e => e.Artist_id)
                    .HasColumnName("Artist_id");

                entity.Property(e => e.Genre_id)
                    .HasColumnName("Genre_id");

                entity.Property(e => e.Country_id)
                    .HasColumnName("Country_id");

                entity.Property(e => e.Artist_Site_URL)
                    .IsUnicode(false)
                    .HasColumnName("Artist_Site_URL");

                entity.HasOne(d => d.Genres)
                   .WithMany()
                   .HasForeignKey(d => d.Genre_id);

                entity.HasOne(d => d.Countries)
                   .WithMany()
                   .HasForeignKey(d => d.Country_id);
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Country_id);

                entity.Property(e => e.Country_id)
                    .HasColumnName("Country_id");

                entity.Property(e => e.Country_name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Country_name");

            });
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Genre_id);

                entity.Property(e => e.Genre_id)
                    .HasColumnName("Genre_id");

                entity.Property(e => e.Genre_name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Genre_name");
            });
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Artist_id);

                entity.Property(e => e.Artist_id)
                    .HasColumnName("Artist_id");

                entity.Property(e => e.Group_name)
                    .HasColumnName("Group_name");
                
                entity.HasOne(d => d.Artists)
                   .WithMany()
                   .HasForeignKey(d => d.Artist_id);
            });
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Artist_id);

                entity.Property(e => e.Artist_id)
                    .HasColumnName("Artist_id");

                entity.Property(e => e.First_name)
                    .HasColumnName("First_name");

                entity.Property(e => e.Last_name)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("Birthday");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sex");

                entity.HasOne(d => d.Artists)
                   .WithMany()
                   .HasForeignKey(d => d.Artist_id);
            });
            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.Song_id);

                entity.Property(e => e.Song_id)
                    .HasColumnName("Song_id");

                entity.Property(e => e.Song_Title)
                    .HasColumnName("Song_Title");

                entity.Property(e => e.Song_Duration)
                    .HasColumnName("Song_Duration");

            });

        }

        
    }
}
