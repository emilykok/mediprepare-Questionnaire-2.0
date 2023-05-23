﻿// <auto-generated />
using System;
using MediPrepareQuestionair.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediPrepareQuestionair.Migrations
{
    [DbContext(typeof(MediPrepareContext))]
    partial class MediPrepareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferenceFormId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferencePatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceFormId");

                    b.HasIndex("ReferencePatientId");

                    b.ToTable("AnswerForms");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerSectionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerSectionId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferenceQuestionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnswerSectionId");

                    b.HasIndex("AnswerSectionId1");

                    b.HasIndex("ReferenceQuestionId");

                    b.ToTable("AnswerQuestions");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerFormId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerFormId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ReferenceSectionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnswerFormId");

                    b.HasIndex("AnswerFormId1");

                    b.HasIndex("ReferenceSectionId");

                    b.ToTable("AnswerSections");
                });

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

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionEventInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnswerFormId")
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

                    b.HasKey("Id");

                    b.HasIndex("AnswerFormId");

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

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DependsOnSectionId");

                    b.HasIndex("FormId");

                    b.ToTable("Sections");
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

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerForm", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.Form", "ReferenceForm")
                        .WithMany()
                        .HasForeignKey("ReferenceFormId");

                    b.HasOne("MediPrepareQuestionair.Models.Patient", "ReferencePatient")
                        .WithMany("Forms")
                        .HasForeignKey("ReferencePatientId");

                    b.Navigation("ReferenceForm");

                    b.Navigation("ReferencePatient");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerQuestion", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.AnswerSection", null)
                        .WithMany("AnswerQuestions")
                        .HasForeignKey("AnswerSectionId");

                    b.HasOne("MediPrepareQuestionair.Database.AnswerSection", null)
                        .WithMany()
                        .HasForeignKey("AnswerSectionId1");

                    b.HasOne("MediPrepareQuestionair.Database.QuestionComponent", "ReferenceQuestion")
                        .WithMany()
                        .HasForeignKey("ReferenceQuestionId");

                    b.OwnsMany("MediPrepareQuestionair.Database.QuestionAnswerValue", "Value", b1 =>
                        {
                            b1.Property<Guid>("AnswerQuestionId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("AnswerQuestionId", "Id");

                            b1.ToTable("QuestionAnswerValue");

                            b1.WithOwner()
                                .HasForeignKey("AnswerQuestionId");
                        });

                    b.Navigation("ReferenceQuestion");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerSection", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.AnswerForm", null)
                        .WithMany("AnswerSections")
                        .HasForeignKey("AnswerFormId");

                    b.HasOne("MediPrepareQuestionair.Database.AnswerForm", null)
                        .WithMany()
                        .HasForeignKey("AnswerFormId1");

                    b.HasOne("MediPrepareQuestionair.Database.Section", "ReferenceSection")
                        .WithMany()
                        .HasForeignKey("ReferenceSectionId");

                    b.Navigation("ReferenceSection");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionComponent", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.Section", null)
                        .WithMany("Questions")
                        .HasForeignKey("SectionId");

                    b.OwnsMany("MediPrepareQuestionair.Database.QuestionOptions", "Options", b1 =>
                        {
                            b1.Property<Guid>("QuestionId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Option")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("QuestionId", "Id");

                            b1.ToTable("QuestionOptions");

                            b1.WithOwner()
                                .HasForeignKey("QuestionId");
                        });

                    b.Navigation("Options");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.QuestionEventInput", b =>
                {
                    b.HasOne("MediPrepareQuestionair.Database.AnswerForm", null)
                        .WithMany("QuestionEventInputs")
                        .HasForeignKey("AnswerFormId");
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

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerForm", b =>
                {
                    b.Navigation("AnswerSections");

                    b.Navigation("QuestionEventInputs");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.AnswerSection", b =>
                {
                    b.Navigation("AnswerQuestions");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Form", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Database.Section", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("MediPrepareQuestionair.Models.Patient", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
