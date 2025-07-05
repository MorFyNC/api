using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIkvalik.Models;

public partial class AnimalArmiContext : DbContext
{
    public AnimalArmiContext()
    {
    }

    public AnimalArmiContext(DbContextOptions<AnimalArmiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feed> Feeds { get; set; }

    public virtual DbSet<MedKartum> MedKarta { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Prank> Pranks { get; set; }

    public virtual DbSet<PranksPet> PranksPets { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sweet> Sweets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6HJ8V04;Database=AnimalArmi;Encrypt=False;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feed>(entity =>
        {
            entity.ToTable("Feed");

            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            entity.Property(e => e.PetId).HasColumnName("Pet_id");
            entity.Property(e => e.SweetId).HasColumnName("Sweet_id");

            entity.HasOne(d => d.Pet).WithMany(p => p.Feeds)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feed_Pet");

            entity.HasOne(d => d.Sweet).WithMany(p => p.Feeds)
                .HasForeignKey(d => d.SweetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feed_Sweet");
        });

        modelBuilder.Entity<MedKartum>(entity =>
        {
            entity.ToTable("Med_karta");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Disease).HasMaxLength(50);
            entity.Property(e => e.Medicine).HasMaxLength(50);
            entity.Property(e => e.PetId).HasColumnName("Pet_id");
            entity.Property(e => e.Vaccine).HasMaxLength(50);

            entity.HasOne(d => d.Pet).WithMany(p => p.MedKarta)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Med_karta_Pet");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.ToTable("Pet");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TypeId).HasColumnName("Type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Pets)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pet_Type");
        });

        modelBuilder.Entity<PranksPet>(entity =>
        {
            entity.ToTable("Pranks_pets");

            entity.Property(e => e.PetId).HasColumnName("Pet_id");
            entity.Property(e => e.PrankId).HasColumnName("Prank_id");

            entity.HasOne(d => d.Pet).WithMany(p => p.PranksPets)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_Pranks_pets_Pet");

            entity.HasOne(d => d.Prank).WithMany(p => p.PranksPets)
                .HasForeignKey(d => d.PrankId)
                .HasConstraintName("FK_Pranks_pets_Pranks");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sweet>(entity =>
        {
            entity.ToTable("Sweet");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.ToTable("Train");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PetId).HasColumnName("Pet_id");
            entity.Property(e => e.Trick).HasMaxLength(50);

            entity.HasOne(d => d.Pet).WithMany(p => p.Trains)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Train_Pet");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.IdRole).HasColumnName("Id_role");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
