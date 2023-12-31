﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltraSoundWeb.Repositories.Context;

#nullable disable

namespace UltraSoundWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UltraSoundWeb.Entities.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SpecializedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpecializedId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Doctor Admin",
                            SpecializedId = 4L,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Info", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicConclusion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicDescriptionResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicRecommendation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.ResultImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UltraSoundResultId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UltraSoundResultId");

                    b.ToTable("ResultImages");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Specialized", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializeds");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Bác sĩ siêu âm"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Bác sĩ chỉ định"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Bác sĩ kê toa"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Bác sĩ quản lý"
                        });
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.UltraSoundResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Conclusion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DoctorSpecifyId")
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorUltraSoundId")
                        .HasColumnType("bigint");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Recommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UltraSoundSampleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorSpecifyId");

                    b.HasIndex("PatientId");

                    b.HasIndex("UltraSoundSampleId");

                    b.ToTable("UltraSoundResults");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.UltraSoundSample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DefaultConclusion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultDiagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultRecommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SampleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UltraSoundSamples");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Password = "i2yBMU+FxDo=",
                            Role = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Doctor", b =>
                {
                    b.HasOne("UltraSoundWeb.Entities.Specialized", "Specialized")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializedId");

                    b.HasOne("UltraSoundWeb.Entities.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("UltraSoundWeb.Entities.Doctor", "UserId");

                    b.Navigation("Specialized");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.ResultImage", b =>
                {
                    b.HasOne("UltraSoundWeb.Entities.UltraSoundResult", "UltraSoundResult")
                        .WithMany("ResultImages")
                        .HasForeignKey("UltraSoundResultId");

                    b.Navigation("UltraSoundResult");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.UltraSoundResult", b =>
                {
                    b.HasOne("UltraSoundWeb.Entities.Doctor", "DoctorSpecify")
                        .WithMany("UltraSoundResults")
                        .HasForeignKey("DoctorSpecifyId");

                    b.HasOne("UltraSoundWeb.Entities.Patient", "Patient")
                        .WithMany("Results")
                        .HasForeignKey("PatientId");

                    b.HasOne("UltraSoundWeb.Entities.UltraSoundSample", "UltraSoundSample")
                        .WithMany("UltraSoundResults")
                        .HasForeignKey("UltraSoundSampleId");

                    b.Navigation("DoctorSpecify");

                    b.Navigation("Patient");

                    b.Navigation("UltraSoundSample");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Doctor", b =>
                {
                    b.Navigation("UltraSoundResults");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Patient", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.Specialized", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.UltraSoundResult", b =>
                {
                    b.Navigation("ResultImages");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.UltraSoundSample", b =>
                {
                    b.Navigation("UltraSoundResults");
                });

            modelBuilder.Entity("UltraSoundWeb.Entities.User", b =>
                {
                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
