using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IMS_DBFirst.Models;

public partial class EfRefContext : DbContext
{
    public EfRefContext()
    {
    }

    public EfRefContext(DbContextOptions<EfRefContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientCity> ClientCities { get; set; }

    public virtual DbSet<ClientInvestment> ClientInvestments { get; set; }

    public virtual DbSet<ClientState> ClientStates { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<InvestmentType> InvestmentTypes { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=MONIKA\\SQLEXPRESS;Initial Catalog=Ef_ref;Integrated Security=True;TrustServerCertificate=True");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
         

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__75A5D7181E544345");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("Client_ID");
            entity.Property(e => e.BirthDate).HasColumnName("Birth_Date");
            entity.Property(e => e.CityId).HasColumnName("City_ID");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PanCardNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PAN_Card_No");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.RegistrationDate).HasColumnName("Registration_Date");
            entity.Property(e => e.StateId).HasColumnName("State_ID");
            entity.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Street_Name");

            entity.HasOne(d => d.City).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client__City_ID__656C112C");

            entity.HasOne(d => d.State).WithMany(p => p.Clients)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client__State_ID__66603565");
        });

        modelBuilder.Entity<ClientCity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Client_C__DE9DE020CA906276");

            entity.ToTable("ClientCity");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("City_ID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("City_Name");
        });

        modelBuilder.Entity<ClientInvestment>(entity =>
        {
            entity.HasKey(e => e.ClientInvestmentId).HasName("PK__Client_I__125BA18A1DBA30AB");

            entity.ToTable("Client_Investment");

            entity.Property(e => e.ClientInvestmentId)
                .ValueGeneratedNever()
                .HasColumnName("Client_Investment_ID");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.InvestmentAmount)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("Investment_Amount");
            entity.Property(e => e.InvestmentDate).HasColumnName("Investment_Date");
            entity.Property(e => e.InvestmentId).HasColumnName("Investment_ID");
            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientInvestments)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Client_In__Clien__0D7A0286");

            entity.HasOne(d => d.Investment).WithMany(p => p.ClientInvestments)
                .HasForeignKey(d => d.InvestmentId)
                .HasConstraintName("FK__Client_In__Inves__0E6E26BF");
        });

        modelBuilder.Entity<ClientState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__Client_S__AF9338D7CAE0F43D");

            entity.ToTable("ClientState");

            entity.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("State_ID");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("State_Name");
        });

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.HasKey(e => e.InvestmentId).HasName("PK__Investme__0C059B9CAEB9C5C3");

            entity.ToTable("Investment");

            entity.Property(e => e.InvestmentId)
                .ValueGeneratedNever()
                .HasColumnName("Investment_ID");
            entity.Property(e => e.InvestmentTypeId).HasColumnName("Investment_Type_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseDate).HasColumnName("Purchase_Date");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Purchase_Price");

            entity.HasOne(d => d.InvestmentType).WithMany(p => p.Investments)
                .HasForeignKey(d => d.InvestmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Investmen__Inves__70DDC3D8");
        });

        modelBuilder.Entity<InvestmentType>(entity =>
        {
            entity.HasKey(e => e.InvestmentTypeId).HasName("PK__Investme__D52DA326AF8A2DE6");

            entity.ToTable("Investment_Type");

            entity.Property(e => e.InvestmentTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Investment_Type_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9A8D562523252D79");

            entity.ToTable("Transaction_Detail");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("Transaction_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TransactionDate).HasColumnName("Transaction_Date");
            entity.Property(e => e.TransactionTypeId).HasColumnName("Transaction_Type_ID");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.TransactionTypeId)
                .HasConstraintName("FK__Transacti__Trans__1332DBDC");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeId).HasName("PK__Transact__6E05F51FD881D22D");

            entity.ToTable("Transaction_Type");

            entity.Property(e => e.TransactionTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Transaction_Type_ID");
            entity.Property(e => e.TransactionType1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
