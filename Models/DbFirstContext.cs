using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenDucChinh_DBFirst.Models;

public partial class DbFirstContext : DbContext
{
    public DbFirstContext()
    {
    }

    public DbFirstContext(DbContextOptions<DbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=JOEL-MILLER\\SQLEXPRESS;Initial Catalog=db_first;User ID=sa;Password=0915146847;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__KHOA__C79B8C2237E05765");

            entity.ToTable("KHOA");

            entity.Property(e => e.MaKhoa)
                .ValueGeneratedNever()
                .HasColumnName("maKhoa");
            entity.Property(e => e.TenKhoa)
                .HasMaxLength(50)
                .HasColumnName("tenKhoa");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__LOP__261ECAE3956AFD03");

            entity.ToTable("LOP");

            entity.Property(e => e.MaLop)
                .ValueGeneratedNever()
                .HasColumnName("maLop");
            entity.Property(e => e.MaKhoa).HasColumnName("maKhoa");
            entity.Property(e => e.TenLop)
                .HasMaxLength(50)
                .HasColumnName("tenLop");

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__LOP__maKhoa__398D8EEE");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SINHVIEN__7A227A641CF06F5F");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.MaSv)
                .ValueGeneratedNever()
                .HasColumnName("maSV");
            entity.Property(e => e.MaLop).HasColumnName("maLop");
            entity.Property(e => e.TenSv)
                .HasMaxLength(50)
                .HasColumnName("tenSV");
            entity.Property(e => e.Tuoi).HasColumnName("tuoi");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SINHVIEN__maLop__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
