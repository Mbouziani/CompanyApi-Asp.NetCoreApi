using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyApi.Models
{
    public partial class db_a8d373_aljazerasoftContext : DbContext
    {
        public db_a8d373_aljazerasoftContext()
        {
        }

        public db_a8d373_aljazerasoftContext(DbContextOptions<db_a8d373_aljazerasoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientCompany> ClientCompanies { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.ClientActiveStatus).HasColumnName("clientActiveStatus");

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(200)
                    .HasColumnName("clientEmail");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(250)
                    .HasColumnName("clientName");

                entity.Property(e => e.ClientPhone)
                    .HasMaxLength(20)
                    .HasColumnName("clientPhone");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(50)
                    .HasColumnName("createAt");
            });

            modelBuilder.Entity<ClientCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__clientCo__AD5459B0A5D79DD1");

                entity.ToTable("clientCompany");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.CompanyActiveStatus).HasColumnName("companyActiveStatus");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(500)
                    .HasColumnName("companyAddress");

                entity.Property(e => e.CompanyCommercial)
                    .HasMaxLength(100)
                    .HasColumnName("companyCommercial");

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(250)
                    .HasColumnName("companyEmail");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(250)
                    .HasColumnName("companyName");

                entity.Property(e => e.CompanyNumber).HasColumnName("companyNumber");

                entity.Property(e => e.CompanyPasswrod)
                    .HasMaxLength(250)
                    .HasColumnName("companyPasswrod");

                entity.Property(e => e.CompanyPhone)
                    .HasMaxLength(20)
                    .HasColumnName("companyPhone");

                entity.Property(e => e.CompanyTaxNumber)
                    .HasMaxLength(100)
                    .HasColumnName("companyTaxNumber");

                entity.Property(e => e.CompanyUsernam)
                    .HasMaxLength(250)
                    .HasColumnName("companyUsernam");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(50)
                    .HasColumnName("createAt");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCompanies)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__clientCom__clien__2E1BDC42");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(500)
                    .HasColumnName("companyAddress");

                entity.Property(e => e.CompanyCommercial)
                    .HasMaxLength(100)
                    .HasColumnName("companyCommercial");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(250)
                    .HasColumnName("companyName");

                entity.Property(e => e.CompanyNumber).HasColumnName("companyNumber");

                entity.Property(e => e.CompanyPhone)
                    .HasMaxLength(20)
                    .HasColumnName("companyPhone");

                entity.Property(e => e.CompanyTaxNumber)
                    .HasMaxLength(100)
                    .HasColumnName("companyTaxNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
