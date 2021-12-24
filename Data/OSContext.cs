using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using aarb.Models;

#nullable disable

namespace aarb.Data
{
    public partial class OSContext : DbContext
    {
        public OSContext()
        {
        }

        public OSContext(DbContextOptions<OSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AafinanceBureau> AafinanceBureaus { get; set; }
        public virtual DbSet<AarevenueBureau> AarevenueBureaus { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchLevel> BranchLevels { get; set; }
        public virtual DbSet<TaxCenter> TaxCenters { get; set; }
        public virtual DbSet<Woredum> Woreda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4LEALLU;Initial Catalog=OS;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AafinanceBureau>(entity =>
            {
                entity.HasKey(e => e.BudgetYearId)
                    .HasName("PK__AAFinanc__7C0CFDE0E2BF1A76");
            });

            modelBuilder.Entity<AarevenueBureau>(entity =>
            {
                entity.HasKey(e => e.BudgetYearId)
                    .HasName("PK__AARevenu__B886CB43C687F3DC");

                entity.Property(e => e.BudgetYearId).ValueGeneratedNever();

                entity.HasOne(d => d.BudgetYearNavigation)
                    .WithOne(p => p.AarevenueBureau)
                    .HasForeignKey<AarevenueBureau>(d => d.BudgetYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AARevenueBureau_AAFinanceBureau");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasOne(d => d.BranchLevel)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.BranchLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch_BranchLevel");
            });

            modelBuilder.Entity<BranchLevel>(entity =>
            {
                entity.HasOne(d => d.BudgetYear)
                    .WithMany(p => p.BranchLevels)
                    .HasForeignKey(d => d.BudgetYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BranchLevel_AARevenueBureau");
            });

            modelBuilder.Entity<TaxCenter>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TaxCenters)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxCenter_Branch");
            });

            modelBuilder.Entity<Woredum>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Woreda)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Woreda_Branch");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
