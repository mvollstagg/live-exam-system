﻿// <auto-generated />
using System;
using LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    [DbContext(typeof(LiveExamSystemContext))]
    partial class LiveExamSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MapCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AppConfigs");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppSeo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppSeoCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AppSeos");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TokenExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            GuId = "39b4c61a7d0f4be59e517c0d7dd2422a",
                            IsActived = true,
                            LastName = "Admin",
                            PasswordHash = "095a8498ec053122d79576e14906c23f9a4f74e82e8de7c52cbfc610f0e7471b118b95d93dc674dcb3293d51303fe52ae7c276af98f8083ccc57bac7c48e96d6",
                            Role = "Admin",
                            SecretKey = "667f1bf1d9e34094922239b0678dfcf323.05.2022225656",
                            Token = "",
                            TokenExpiryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppUserExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RightAnswer")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("WrongAnswer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ExamId");

                    b.ToTable("AppUserExam");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsExam")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsQuestion")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SlugUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentFolderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentSize")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentUnique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image_Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Storage_Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Video_Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SlugUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UserStartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Letter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAnnoted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Answer", b =>
                {
                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppUserExam", b =>
                {
                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.AppUser", "AppUser")
                        .WithMany("AppUserExams")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Category", b =>
                {
                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Exam", b =>
                {
                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Category", "Category")
                        .WithMany("Exams")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Question", b =>
                {
                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveExamSystemWebApp.Entities.Concrete.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("AppUserExams");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Exams");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("LiveExamSystemWebApp.Entities.Concrete.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
