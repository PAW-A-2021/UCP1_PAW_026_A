using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1_PAW_026_A.Models
{
    public partial class PesanMakananContext : DbContext
    {
        public PesanMakananContext()
        {
        }

        public PesanMakananContext(DbContextOptions<PesanMakananContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Kurir> Kurir { get; set; }
        public virtual DbSet<Makanan> Makanan { get; set; }
        public virtual DbSet<Pelanggan> Pelanggan { get; set; }
        public virtual DbSet<Pesanan> Pesanan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("ID_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaAdmin)
                    .HasColumnName("Nama_admin")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_HP")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kurir>(entity =>
            {
                entity.HasKey(e => e.IdKurir);

                entity.Property(e => e.IdKurir)
                    .HasColumnName("ID_Kurir")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaKurir)
                    .HasColumnName("Nama_Kurir")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp).HasColumnName("No_HP");
            });

            modelBuilder.Entity<Makanan>(entity =>
            {
                entity.HasKey(e => e.IdMakanan);

                entity.Property(e => e.IdMakanan)
                    .HasColumnName("ID_Makanan")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaMakanan).HasColumnName("Harga_Makanan");

                entity.Property(e => e.Ketersediaan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaMakanan)
                    .HasColumnName("Nama_Makanan")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelanggan>(entity =>
            {
                entity.HasKey(e => e.IdPelanggan);

                entity.Property(e => e.IdPelanggan)
                    .HasColumnName("ID_Pelanggan")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPelanggan)
                    .HasColumnName("Nama_Pelanggan")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_HP")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pesanan>(entity =>
            {
                entity.HasKey(e => e.IdPesanan);

                entity.Property(e => e.IdPesanan)
                    .HasColumnName("ID_Pesanan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdKurir).HasColumnName("ID_Kurir");

                entity.Property(e => e.IdMakanan).HasColumnName("ID_Makanan");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.TglPemesanan)
                    .HasColumnName("Tgl_Pemesanan")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalHarga).HasColumnName("Total_Harga");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Pesanan_Admin");

                entity.HasOne(d => d.IdKurirNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdKurir)
                    .HasConstraintName("FK_Pesanan_Kurir");

                entity.HasOne(d => d.IdMakananNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdMakanan)
                    .HasConstraintName("FK_Pesanan_Makanan");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Pesanan_Pelanggan");
            });
        }
    }
}
