﻿// <auto-generated />
using System;
using LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiveExamSystemWebApp.DataAccess.Migrations
{
    [DbContext(typeof(LiveExamSystemContext))]
    [Migration("20220626194817_v11_AppUserExamIsEnd")]
    partial class v11_AppUserExamIsEnd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            GuId = "180dec2cf3a64b6eb3a87c51600035ff",
                            IsActived = true,
                            LastName = "Admin",
                            PasswordHash = "a70ebc46dd65777ece6620dddb4cde2aa68c83352e54611285206dbc59189ff2aef56892702fcea6e1d63bd58837742e9021832307b77a623e5211e87981230d",
                            Role = "Admin",
                            SecretKey = "647055b9da774bcbadd3448c2aba0bc026.06.2022224817",
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

                    b.Property<bool>("IsEnd")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("RightAnswer")
                        .HasColumnType("int");

                    b.Property<float?>("Score")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UserStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("WrongAnswer")
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

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("FileCode")
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
