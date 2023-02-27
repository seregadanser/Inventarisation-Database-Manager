using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_course;

public partial class WarehouseContext : DbContext
{
    public WarehouseContext()
    {
    }

    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InventoryProduct> InventoryProducts { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceofObject> PlaceofObjects { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Useful> Usefuls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TPNKBFP;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC077AD6E2A1");

            entity.ToTable("InventoryProduct", "warehouse2");

            entity.HasIndex(e => e.InventoryNumber, "UQ__Inventor__070F296CF84897E5").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InventoryNumber).HasColumnName("inventory_number");
            entity.Property(e => e.ProductId).HasColumnName("product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__produ__276EDEB3");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC0777E9B0A3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirthday).HasColumnType("date");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Place__3214EC078A021FF3");

            entity.ToTable("Place", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NumberLayer).HasColumnName("number_layer");
            entity.Property(e => e.NumberStay).HasColumnName("number_stay");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<PlaceofObject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceofO__3214EC07F2399B56");

            entity.ToTable("PlaceofObject", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Inventory).WithMany(p => p.PlaceofObjects)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("FK__PlaceofOb__Inven__2D27B809");

            entity.HasOne(d => d.Place).WithMany(p => p.PlaceofObjects)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__PlaceofOb__Place__2C3393D0");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07888CC753");

            entity.ToTable("Products", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCome)
                .HasColumnType("date")
                .HasColumnName("dateCome");
            entity.Property(e => e.DateProduction)
                .HasColumnType("date")
                .HasColumnName("dateProduction");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Useful>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Useful__3214EC07AD45DB4A");

            entity.ToTable("Useful", "warehouse2");

            entity.HasIndex(e => e.InventoryId, "UQ__Useful__F5FDE6B2B760517D").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfStart).HasColumnType("date");

            entity.HasOne(d => d.Inventory).WithOne(p => p.Useful)
                .HasForeignKey<Useful>(d => d.InventoryId)
                .HasConstraintName("FK__Useful__Inventor__32E0915F");

            entity.HasOne(d => d.Person).WithMany(p => p.Usefuls)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Useful__PersonId__33D4B598");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
