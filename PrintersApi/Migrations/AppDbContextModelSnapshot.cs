﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PrintersApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("Setor")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Printers");
                });

            modelBuilder.Entity("Selb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PrinterId")
                        .HasColumnType("int");

                    b.Property<int>("TonnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrinterId");

                    b.HasIndex("TonnerId");

                    b.ToTable("Selbs");
                });

            modelBuilder.Entity("Tonner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("longtext");

                    b.Property<string>("Printer")
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tonners");
                });

            modelBuilder.Entity("Selb", b =>
                {
                    b.HasOne("Printer", "Printer")
                        .WithMany("Selbs")
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tonner", "Tonner")
                        .WithMany("Selbs")
                        .HasForeignKey("TonnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Printer");

                    b.Navigation("Tonner");
                });

            modelBuilder.Entity("Printer", b =>
                {
                    b.Navigation("Selbs");
                });

            modelBuilder.Entity("Tonner", b =>
                {
                    b.Navigation("Selbs");
                });
#pragma warning restore 612, 618
        }
    }
}
