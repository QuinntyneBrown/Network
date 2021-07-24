﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Network.Api.Data;

namespace Network.Api.Migrations
{
    [DbContext(typeof(NetworkDbContext))]
    partial class NetworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Network.Api.Models.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Network.Api.Models.DigitalAsset", b =>
                {
                    b.Property<Guid>("DigitalAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Bytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DigitalAssetId");

                    b.ToTable("DigitalAssets");
                });

            modelBuilder.Entity("Network.Api.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Network.Api.Models.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Network.Api.Models.Organization", b =>
                {
                    b.Property<Guid>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Network.Api.Models.Position", b =>
                {
                    b.Property<Guid>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<int>("PositionType")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Senority")
                        .HasColumnType("int");

                    b.Property<int>("Stack")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Network.Api.Models.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AvatarDigitalAssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Network.Api.Models.ProfileNote", b =>
                {
                    b.Property<Guid>("ProfileNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileNoteId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileNotes");
                });

            modelBuilder.Entity("Network.Api.Models.Company", b =>
                {
                    b.HasOne("Network.Api.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Network.Api.Models.Organization", null)
                        .WithMany("Companies")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Network.Api.Models.Position", b =>
                {
                    b.HasOne("Network.Api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Network.Api.Models.Profile", null)
                        .WithMany("Experience")
                        .HasForeignKey("ProfileId");

                    b.OwnsOne("Network.Api.Models.DatesEmployed", "DatesEmployed", b1 =>
                        {
                            b1.Property<Guid>("PositionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("PositionId");

                            b1.ToTable("Positions");

                            b1.WithOwner()
                                .HasForeignKey("PositionId");
                        });

                    b.Navigation("Company");

                    b.Navigation("DatesEmployed");
                });

            modelBuilder.Entity("Network.Api.Models.ProfileNote", b =>
                {
                    b.HasOne("Network.Api.Models.Profile", null)
                        .WithMany("ProfileNotes")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Network.Api.Models.Organization", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Network.Api.Models.Profile", b =>
                {
                    b.Navigation("Experience");

                    b.Navigation("ProfileNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
