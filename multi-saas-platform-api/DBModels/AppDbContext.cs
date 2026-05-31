using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace multi_saas_platform_api.DBModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Businesslicense> Businesslicenses { get; set; }

    public virtual DbSet<Businessproduct> Businessproducts { get; set; }

    public virtual DbSet<Masterproduct> Masterproducts { get; set; }

    public virtual DbSet<Masterrole> Masterroles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=multisaasplatform;user=root;password=InnoTech@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.46-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Businesslicense>(entity =>
        {
            entity.HasKey(e => e.LicenseId).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.MaxBranches).HasDefaultValueSql("'1'");
            entity.Property(e => e.MaxUsers).HasDefaultValueSql("'5'");

            entity.HasOne(d => d.Business).WithMany(p => p.Businesslicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businesslicenses_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Businesslicenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businesslicenses_ibfk_2");
        });

        modelBuilder.Entity<Businessproduct>(entity =>
        {
            entity.HasKey(e => e.BusinessProductId).HasName("PRIMARY");

            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Business).WithMany(p => p.Businessproducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businessproducts_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Businessproducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businessproducts_ibfk_2");
        });

        modelBuilder.Entity<Masterproduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<Masterrole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("1=Active, 0=Inactive");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Business).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_business");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
