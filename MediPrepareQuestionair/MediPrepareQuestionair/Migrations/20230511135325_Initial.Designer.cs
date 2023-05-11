﻿// <auto-generated />
using System;
using MediPrepareQuestionair.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediPrepareQuestionair.Migrations
{
    [DbContext(typeof(MediPrepareContext))]
    [Migration("20230511135325_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MediPrepareQuestionair.Database.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Value");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Type").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionEventInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuestionVersion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserFormId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserFormId");

                    b.ToTable("QuestionEventInputs");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DependsOnSectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FormId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DependsOnSectionId");

                    b.HasIndex("FormId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.UserForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferenceFormId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReferencePatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceFormId");

                    b.HasIndex("ReferencePatientId");

                    b.ToTable("UserForms");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.DateTimeQuestion", b =>
                {
                    b.HasBaseType("MediPrepareQuestionair.Database.Question");

                    b.Property<DateTime>("DateValue")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("DateTimeQuestion");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Question", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.Section", null)
                        .WithMany("Questions")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionEventInput", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.UserForm", null)
                        .WithMany("QuestionEventInputs")
                        .HasForeignKey("UserFormId");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Section", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.Section", "DependsOnSection")
                        .WithMany()
                        .HasForeignKey("DependsOnSectionId");

                    b.HasOne("MediPrepareQuestionair.Database.Form", null)
                        .WithMany("Sections")
                        .HasForeignKey("FormId");

                    b.Navigation("DependsOnSection");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.UserForm", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.Form", "ReferenceForm")
                        .WithMany()
                        .HasForeignKey("ReferenceFormId");

                    b.HasOne("MediPrepareQuestionair.Models.Patient", "ReferencePatient")
                        .WithMany("Forms")
                        .HasForeignKey("ReferencePatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReferenceForm");

                    b.Navigation("ReferencePatient");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Form", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Section", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.UserForm", b =>
                {
                    b.Navigation("QuestionEventInputs");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Models.Patient", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
