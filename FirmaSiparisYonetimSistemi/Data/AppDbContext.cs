using Microsoft.EntityFrameworkCore;
using FirmaSiparisYonetimSistemi.Models;


namespace FirmaSiparisYonetimSistemi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urunler> Urunler { get; set; }

        public DbSet<Siparis> Siparisler { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>().HasKey(f => f.FirmaId);
            modelBuilder.Entity<Urunler>().HasKey(u => u.UrunId);
            modelBuilder.Entity<Siparis>().HasKey(s => s.SiparisId);

            modelBuilder.Entity<Firma>()
                .HasMany(f => f.Urunler)
                .WithOne(u => u.Firma)
                .HasForeignKey(u => u.FirmaId)
                .OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction

            modelBuilder.Entity<Firma>()
                .HasMany(f => f.Siparisler)
                .WithOne(s => s.Firma)
                .HasForeignKey(s => s.FirmaId)
                .OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction

            modelBuilder.Entity<Siparis>()
                .HasOne(s => s.Urun)
                .WithMany(u => u.Siparisler)
                .HasForeignKey(s => s.UrunId)
                .OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction
        }
    }
}
