using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class KlubSportowyContext : DbContext
    {
        public KlubSportowyContext()
        {
        }

        public KlubSportowyContext(DbContextOptions<KlubSportowyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fizjoterapeuci> Fizjoterapeucis { get; set; }
        public virtual DbSet<Kontrakty> Kontrakties { get; set; }
        public virtual DbSet<Kontuzje> Kontuzjes { get; set; }
        public virtual DbSet<Trenerzy> Trenerzies { get; set; }
        public virtual DbSet<Zawodnicy> Zawodnicies { get; set; }
        public virtual DbSet<Zespoly> Zespolies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_Poland.1250");

            modelBuilder.Entity<Fizjoterapeuci>(entity =>
            {
                entity.HasKey(e => e.IdFizjoterapeuta)
                    .HasName("fizjoterapeuci_pkey");

                entity.ToTable("fizjoterapeuci");

                entity.Property(e => e.IdFizjoterapeuta).HasColumnName("id_fizjoterapeuta");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("imie");

                entity.Property(e => e.KontraktId).HasColumnName("kontrakt_id");

                entity.Property(e => e.Narodowosc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("narodowosc");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Plec)
                    .HasMaxLength(1)
                    .HasColumnName("plec");

                entity.HasOne(d => d.Kontrakt)
                    .WithMany(p => p.Fizjoterapeucis)
                    .HasForeignKey(d => d.KontraktId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fizjoterapeuci_kontrakt_id_fkey");
            });

            modelBuilder.Entity<Kontrakty>(entity =>
            {
                entity.HasKey(e => e.IdKontrakt)
                    .HasName("kontrakty_pkey");

                entity.ToTable("kontrakty");

                entity.Property(e => e.IdKontrakt).HasColumnName("id_kontrakt");

                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnType("date")
                    .HasColumnName("data_rozpoczecia");

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnType("date")
                    .HasColumnName("data_zakonczenia");

                entity.Property(e => e.Pensja)
                    .HasPrecision(7, 2)
                    .HasColumnName("pensja");
            });

            modelBuilder.Entity<Kontuzje>(entity =>
            {
                entity.HasKey(e => e.IdKontuzja)
                    .HasName("kontuzje_pkey");

                entity.ToTable("kontuzje");

                entity.Property(e => e.IdKontuzja).HasColumnName("id_kontuzja");

                entity.Property(e => e.DataDoznania)
                    .HasColumnType("date")
                    .HasColumnName("data_doznania");

                entity.Property(e => e.DataWyleczenia)
                    .HasColumnType("date")
                    .HasColumnName("data_wyleczenia");

                entity.Property(e => e.FizjoterapeutaId).HasColumnName("fizjoterapeuta_id");

                entity.Property(e => e.Opis)
                    .HasMaxLength(50)
                    .HasColumnName("opis");

                entity.Property(e => e.ZawodnikId).HasColumnName("zawodnik_id");

                entity.HasOne(d => d.Fizjoterapeuta)
                    .WithMany(p => p.Kontuzjes)
                    .HasForeignKey(d => d.FizjoterapeutaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("kontuzje_fizjoterapeuta_id_fkey");

                entity.HasOne(d => d.Zawodnik)
                    .WithMany(p => p.Kontuzjes)
                    .HasForeignKey(d => d.ZawodnikId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("kontuzje_zawodnik_id_fkey");
            });

            modelBuilder.Entity<Trenerzy>(entity =>
            {
                entity.HasKey(e => e.IdTrener)
                    .HasName("trenerzy_pkey");

                entity.ToTable("trenerzy");

                entity.Property(e => e.IdTrener).HasColumnName("id_trener");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("imie");

                entity.Property(e => e.KontraktId).HasColumnName("kontrakt_id");

                entity.Property(e => e.Narodowosc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("narodowosc");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Plec)
                    .HasMaxLength(1)
                    .HasColumnName("plec");

                entity.HasOne(d => d.Kontrakt)
                    .WithMany(p => p.Trenerzies)
                    .HasForeignKey(d => d.KontraktId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("trenerzy_kontrakt_id_fkey");
            });

            modelBuilder.Entity<Zawodnicy>(entity =>
            {
                entity.HasKey(e => e.IdZawodnik)
                    .HasName("zawodnicy_pkey");

                entity.ToTable("zawodnicy");

                entity.Property(e => e.IdZawodnik).HasColumnName("id_zawodnik");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("date")
                    .HasColumnName("data_urodzenia");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("imie");

                entity.Property(e => e.KontraktId).HasColumnName("kontrakt_id");

                entity.Property(e => e.Narodowosc)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("narodowosc");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Plec)
                    .HasMaxLength(1)
                    .HasColumnName("plec");

                entity.Property(e => e.ZespolId).HasColumnName("zespol_id");

                entity.HasOne(d => d.Kontrakt)
                    .WithMany(p => p.Zawodnicies)
                    .HasForeignKey(d => d.KontraktId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("zawodnicy_kontrakt_id_fkey");

                entity.HasOne(d => d.Zespol)
                    .WithMany(p => p.Zawodnicies)
                    .HasForeignKey(d => d.ZespolId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("zawodnicy_zespol_id_fkey");
            });

            modelBuilder.Entity<Zespoly>(entity =>
            {
                entity.HasKey(e => e.IdZespol)
                    .HasName("zespoly_pkey");

                entity.ToTable("zespoly");

                entity.Property(e => e.IdZespol).HasColumnName("id_zespol");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");

                entity.Property(e => e.TrenerId).HasColumnName("trener_id");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.Zespolies)
                    .HasForeignKey(d => d.TrenerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("zespoly_trener_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
