using Microsoft.EntityFrameworkCore;
using AnaOkuluYS.Models;

namespace AnaOkuluYS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<GelisimRaporu> GelisimRaporlari { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<EtkinlikKatilim> EtkinlikKatilimlari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri tanımla
            modelBuilder.Entity<GelisimRaporu>()
                .HasOne(g => g.Ogrenci)
                .WithMany(o => o.GelisimRaporlari)
                .HasForeignKey(g => g.OgrenciId);

            modelBuilder.Entity<GelisimRaporu>()
                .HasOne(g => g.Ogretmen)
                .WithMany(o => o.GelisimRaporlari)
                .HasForeignKey(g => g.OgretmenId);

            modelBuilder.Entity<Etkinlik>()
                .HasOne(e => e.Ogretmen)
                .WithMany(o => o.Etkinlikler)
                .HasForeignKey(e => e.OgretmenId);

            modelBuilder.Entity<EtkinlikKatilim>()
                .HasOne(ek => ek.Etkinlik)
                .WithMany(e => e.Katilimlar)
                .HasForeignKey(ek => ek.EtkinlikId);

            modelBuilder.Entity<EtkinlikKatilim>()
                .HasOne(ek => ek.Ogrenci)
                .WithMany(o => o.EtkinlikKatilimlari)
                .HasForeignKey(ek => ek.OgrenciId);
        }
    }
} 