using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace controller.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContextconnettion")
        {
        }

        public virtual DbSet<CT_DONHANG> CT_DONHANG { get; set; }
        public virtual DbSet<CT_SDPGG> CT_SDPGG { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<DTAC_TAI_XE> DTAC_TAI_XE { get; set; }
        public virtual DbSet<HOA_DON> HOA_DON { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<PHIEU_GIAM_GIA> PHIEU_GIAM_GIA { get; set; }
        public virtual DbSet<PHIEU_GIAO_HANG> PHIEU_GIAO_HANG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_DONHANG>()
                .Property(e => e.GIABAN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CT_DONHANG>()
                .HasMany(e => e.CT_SDPGG)
                .WithRequired(e => e.CT_DONHANG)
                .HasForeignKey(e => new { e.MA_MON_AN, e.MA_DH })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.PHI_GIAO_HANG)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.CT_DONHANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.PHIEU_GIAO_HANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DTAC_TAI_XE>()
                .HasMany(e => e.DON_HANG)
                .WithRequired(e => e.DTAC_TAI_XE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DTAC_TAI_XE>()
                .HasMany(e => e.PHIEU_GIAO_HANG)
                .WithRequired(e => e.DTAC_TAI_XE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOA_DON>()
                .HasMany(e => e.CT_SDPGG)
                .WithRequired(e => e.HOA_DON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.SDT_KH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.DON_HANG)
                .WithRequired(e => e.KHACH_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MENU>()
                .HasMany(e => e.CT_DONHANG)
                .WithRequired(e => e.MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.HOA_DON)
                .WithRequired(e => e.NHAN_VIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .HasMany(e => e.PHIEU_GIAO_HANG)
                .WithRequired(e => e.NHAN_VIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEU_GIAM_GIA>()
                .HasMany(e => e.CT_SDPGG)
                .WithRequired(e => e.PHIEU_GIAM_GIA)
                .WillCascadeOnDelete(false);
        }
    }
}
