﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlySpans.PolyLeads.Api.Data.Contexts;

#nullable disable

namespace OnlySpans.PolyLeads.Api.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<long?>("FileEntryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FileEntryId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.DocumentGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long?>("ParentGroupId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("DocumentGroups");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.DocumentInGroup", b =>
                {
                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint");

                    b.Property<long>("DocumentGroupId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.HasKey("DocumentId", "DocumentGroupId");

                    b.HasIndex("DocumentGroupId");

                    b.ToTable("DocumentInGroups");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<long>("StorageObjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StorageObjectId")
                        .IsUnique();

                    b.ToTable("FileEntries");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.FileRecognitionStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AssignedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("FileEntryId")
                        .HasColumnType("bigint");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileEntryId");

                    b.ToTable("FileRecognitionStatuses");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.RecognitionResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AllText")
                        .IsRequired()
                        .HasMaxLength(65536)
                        .HasColumnType("character varying(65536)");

                    b.Property<long>("FileEntryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecognisedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FileEntryId");

                    b.ToTable("RecognitionResults");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.StorageObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("StorageAlias")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("StorageId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("StorageObjects");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.Document", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", "FileEntry")
                        .WithOne("Document")
                        .HasForeignKey("OnlySpans.PolyLeads.Api.Data.Entities.Document", "FileEntryId");

                    b.Navigation("FileEntry");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.DocumentGroup", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.DocumentGroup", "ParentGroup")
                        .WithMany("ChildGroups")
                        .HasForeignKey("ParentGroupId");

                    b.Navigation("ParentGroup");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.DocumentInGroup", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.DocumentGroup", "DocumentGroup")
                        .WithMany("DocumentInGroups")
                        .HasForeignKey("DocumentGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.Document", "Document")
                        .WithMany("DocumentInGroups")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("DocumentGroup");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.StorageObject", "StorageObject")
                        .WithOne("FileEntry")
                        .HasForeignKey("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", "StorageObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StorageObject");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.FileRecognitionStatus", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", "FileEntry")
                        .WithMany("RecognitionStatuses")
                        .HasForeignKey("FileEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileEntry");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.RecognitionResult", b =>
                {
                    b.HasOne("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", "FileEntry")
                        .WithMany("RecognitionResults")
                        .HasForeignKey("FileEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileEntry");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.Document", b =>
                {
                    b.Navigation("DocumentInGroups");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.DocumentGroup", b =>
                {
                    b.Navigation("ChildGroups");

                    b.Navigation("DocumentInGroups");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.FileEntry", b =>
                {
                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("RecognitionResults");

                    b.Navigation("RecognitionStatuses");
                });

            modelBuilder.Entity("OnlySpans.PolyLeads.Api.Data.Entities.StorageObject", b =>
                {
                    b.Navigation("FileEntry")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
