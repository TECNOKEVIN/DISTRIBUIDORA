﻿// <auto-generated />
using Distribuidora.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Distribuidora.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Distribuidora.Shared.Entities.Licor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.Property<int>("TipoLicorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoLicorId", "Name")
                        .IsUnique();

                    b.ToTable("Licors");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.Sede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.TipoLicor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SedeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SedeId", "Name")
                        .IsUnique();

                    b.ToTable("TipoLicors");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.Licor", b =>
                {
                    b.HasOne("Distribuidora.Shared.Entities.TipoLicor", "TipoLicor")
                        .WithMany("Licors")
                        .HasForeignKey("TipoLicorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoLicor");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.TipoLicor", b =>
                {
                    b.HasOne("Distribuidora.Shared.Entities.Sede", "Sede")
                        .WithMany("TipoLicors")
                        .HasForeignKey("SedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.Sede", b =>
                {
                    b.Navigation("TipoLicors");
                });

            modelBuilder.Entity("Distribuidora.Shared.Entities.TipoLicor", b =>
                {
                    b.Navigation("Licors");
                });
#pragma warning restore 612, 618
        }
    }
}
