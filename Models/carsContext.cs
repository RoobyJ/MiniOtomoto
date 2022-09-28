using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MiniOtomoto.Models
{
    public partial class carsContext : DbContext
    {
        public carsContext()
        {
        }

        public carsContext(DbContextOptions<carsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Add> Adds { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=cars;user=root;password=pineapple", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Add>(entity =>
            {
                entity.HasKey(e => e.IdAdds)
                    .HasName("PRIMARY");

                entity.ToTable("adds");

                entity.HasIndex(e => e.IdAdds, "id_adds_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdBrand, "id_brand");

                entity.HasIndex(e => e.IdModel, "id_model");

                entity.HasIndex(e => e.IdOffer, "id_offer_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdAdds).HasColumnName("id_adds");

                entity.Property(e => e.Fuel)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("fuel");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.IdOffer).HasColumnName("id_offer");

                entity.Property(e => e.Mileage)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("mileage");

                entity.Property(e => e.Power)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("power");

                entity.Property(e => e.ProductionYear).HasColumnName("production_year");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Adds)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adds_ibfk_1");

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.Adds)
                    .HasForeignKey(d => d.IdModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adds_ibfk_2");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand)
                    .HasName("PRIMARY");

                entity.ToTable("brands");

                entity.HasIndex(e => e.BrandName, "brand_name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdBrand, "id_brands_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(45)
                    .HasColumnName("brand_name");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("PRIMARY");

                entity.ToTable("models");

                entity.HasIndex(e => e.IdBrand, "id_brand");

                entity.HasIndex(e => e.IdModel, "id_model_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ModelName, "model_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("model_name");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("models_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
