
using Microsoft.EntityFrameworkCore;

namespace Covid19.DAL
{
    public class Covid19Context : DbContext
    {
        public Covid19Context()
        {
        }

        public Covid19Context(DbContextOptions<Covid19Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=localhost;Database=QLTinhHinh;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<TrangThai> TrangThais { get; set; }
        public DbSet<DiaPhuong> DiaPhuongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.HasKey(t => t.MaTT);
                entity.Property(t => t.MaTT).ValueGeneratedNever();
                entity.Property(t => t.TenTT).IsRequired().HasMaxLength(100);
                entity.Property(t => t.GhiChu).IsRequired(false);

                entity.HasMany(t => t.DiaPhuongs)
                    .WithOne(d => d.TrangThai)
                    .HasForeignKey(d => d.MaTT)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new TrangThai { MaTT = 1, TenTT = "Bình thường", GhiChu = "không giới hạn" },
                    new TrangThai { MaTT = 2, TenTT = "Cách ly xã hội", GhiChu = "chỉ thị 16" },
                    new TrangThai { MaTT = 3, TenTT = "Khóa chặt đông cứng", GhiChu = null },
                    new TrangThai { MaTT = 4, TenTT = "Bình thường Mới", GhiChu = null }
                );
            });

            modelBuilder.Entity<DiaPhuong>(entity =>
            {
                entity.HasKey(d => d.MaDP);
                entity.Property(d => d.MaDP).HasMaxLength(3).IsRequired();
                entity.Property(d => d.TenDP).HasMaxLength(50).IsRequired();
                entity.Property(d => d.SoCaNhiemMoi).IsRequired();

                entity.HasData(
                    new DiaPhuong { MaDP = "BDU", TenDP = "Bình Dương", SoCaNhiemMoi = 521, MaTT = 4 },
                    new DiaPhuong { MaDP = "DAK", TenDP = "ĐăkLak", SoCaNhiemMoi = 254, MaTT = 2 },
                    new DiaPhuong { MaDP = "DON", TenDP = "Đồng Nai", SoCaNhiemMoi = 499, MaTT = 3 },
                    new DiaPhuong { MaDP = "HNO", TenDP = "Hà Nội", SoCaNhiemMoi = 0, MaTT = 1 },
                    new DiaPhuong { MaDP = "SGN", TenDP = "Tp. HCM", SoCaNhiemMoi = 1140, MaTT = 4 }
                );
            });
        }
    }
}
