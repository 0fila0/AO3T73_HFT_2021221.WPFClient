// <copyright file="ProductsContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace Products.Data.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// This is a custom database context.
    /// </summary>
    public partial class ProductsContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsContext"/> class.
        /// </summary>
        public ProductsContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsContext"/> class.
        /// </summary>
        /// <param name="options"> DBContext option. </param>
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        public static ProductsContext Instance
        {
            get;
            private set;
        }

        = new ProductsContext();

        /// <summary>
        /// Gets or sets Aruhaz data.
        /// </summary>
        public virtual DbSet<Aruhaz> Aruhaz { get; set; }

        /// <summary>
        /// Gets or sets Gyarto data.
        /// </summary>
        public virtual DbSet<Gyarto> Gyarto { get; set; }

        /// <summary>
        /// Gets or sets IDKapcsolo data.
        /// </summary>
        public virtual DbSet<IDKapcsolo> IDKapcsolo { get; set; }

        /// <summary>
        /// Gets or sets Termek data.
        /// </summary>
        public virtual DbSet<Termek> Termek { get; set; }

        /// <summary>
        /// Configures the DBContext.
        /// </summary>
        /// <param name="optionsBuilder"> DbContextOptionsBuilder parameter. </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\ProductsServiceBasedDB.mdf; Integrated Security = True");
                }
            }
        }

        /// <summary>
        /// Create enities model.
        /// </summary>
        /// <param name="modelBuilder"> ModelBuilder parameter. </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

                modelBuilder.Entity<Aruhaz>(entity =>
                {
                    entity.HasKey(e => e.AruhazNeve)
                        .HasName("aruhaz_pk");

                    entity.ToTable("Aruhaz");

                    entity.Property(e => e.AruhazNeve)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("Aruhaz_neve");

                    entity.Property(e => e.Adoszam).HasColumnType("numeric(20, 0)");

                    entity.Property(e => e.EMail)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("E_mail");

                    entity.Property(e => e.Honlap)
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Kozpont)
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.Telefon).HasColumnType("numeric(13, 0)");
                });

                modelBuilder.Entity<Gyarto>(entity =>
                {
                    entity.HasKey(e => e.GyartoNeve)
                        .HasName("gyarto_pk");

                    entity.ToTable("Gyarto");

                    entity.Property(e => e.GyartoNeve)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("Gyarto_neve");

                    entity.Property(e => e.Adoszam).HasColumnType("numeric(20, 0)");

                    entity.Property(e => e.EMail)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("E_mail");

                    entity.Property(e => e.Honlap)
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Kozpont)
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.Telefon).HasColumnType("numeric(13, 0)");
                });

                modelBuilder.Entity<IDKapcsolo>(entity =>
                {
                    entity.HasKey(e => e.KapcsoloId)
                        .HasName("kapcsolo_pk");

                    entity.ToTable("ID_Kapcsolo");

                    entity.Property(e => e.KapcsoloId)
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("Kapcsolo_ID");

                    entity.Property(e => e.AruhazNeve)
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("Aruhaz_neve");

                    entity.Property(e => e.TermekID)
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("Termek_ID");

                    entity.HasOne(d => d.AruhazNeveNavigation)
                        .WithMany(p => p.IdKapcsolos)
                        .HasForeignKey(d => d.AruhazNeve)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("aruhaz_fk");

                    entity.HasOne(d => d.Termek)
                        .WithMany(p => p.IDKapcsolo)
                        .HasForeignKey(d => d.TermekID)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("termek_fk");
                });

                modelBuilder.Entity<Termek>(entity =>
                {
                    entity.ToTable("Termek");

                    entity.Property(e => e.TermekID)
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("Termek_ID");

                    entity.Property(e => e.Ar).HasColumnType("numeric(5, 0)");

                    entity.Property(e => e.GyartoNeve)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("Gyarto_neve");

                    entity.Property(e => e.Kiszereles)
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Leiras)
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    entity.Property(e => e.Megnevezes)
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.Property(e => e.Tipus)
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    entity.HasOne(d => d.GyartoNeveNavigation)
                        .WithMany(p => p.Termek)
                        .HasForeignKey(d => d.GyartoNeve)
                        .HasConstraintName("gyarto_fk");
                });

                this.OnModelCreatingPartial(modelBuilder);
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
