// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhereWasI.Data;

namespace WhereWasI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211109094604_UpdateContext")]
    partial class UpdateContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WhereWasI.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WhereWasI.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LastNumber")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("WhereWasI.Models.ItemCategory", b =>
                {
                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ItemID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("WhereWasI.Models.Anime", b =>
                {
                    b.HasBaseType("WhereWasI.Models.Item");

                    b.Property<int>("season")
                        .HasColumnType("int");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("WhereWasI.Models.ItemCategory", b =>
                {
                    b.HasOne("WhereWasI.Models.Category", "Category")
                        .WithMany("ItemCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhereWasI.Models.Item", "Item")
                        .WithMany("ItemCategories")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WhereWasI.Models.Anime", b =>
                {
                    b.HasOne("WhereWasI.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("WhereWasI.Models.Anime", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhereWasI.Models.Category", b =>
                {
                    b.Navigation("ItemCategories");
                });

            modelBuilder.Entity("WhereWasI.Models.Item", b =>
                {
                    b.Navigation("ItemCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
