using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsList_Command_MVVM_WpfApp2.My_Work.Model;

public partial class ProductslistCommandMvvmDbContext : DbContext
{
    public ProductslistCommandMvvmDbContext()
    {
    }

    public ProductslistCommandMvvmDbContext(DbContextOptions<ProductslistCommandMvvmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Manufactorer> Manufactorers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=\"productslist command mvvm db\"", ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Category1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("Category");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("discount");

            entity.Property(e => e.Discount1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("Discount");
        });

        modelBuilder.Entity<Manufactorer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("manufactorer");

            entity.Property(e => e.Manufactorer1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("Manufactorer");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.Idcategory, "FK_product_IDCategory");

            entity.HasIndex(e => e.Iddiscount, "FK_product_IDDiscount");

            entity.HasIndex(e => e.Idmanufactorer, "FK_product_IDManufactorer");

            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Iddiscount).HasColumnName("IDDiscount");
            entity.Property(e => e.Idmanufactorer).HasColumnName("IDManufactorer");
            entity.Property(e => e.Price).HasPrecision(19, 2);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idcategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_IDCategory");

            entity.HasOne(d => d.IddiscountNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Iddiscount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_IDDiscount");

            entity.HasOne(d => d.IdmanufactorerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idmanufactorer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_IDManufactorer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
