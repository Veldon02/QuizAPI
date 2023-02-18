﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20230217161901_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.QuizAggregate.Quiz", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<byte>("Difficulty")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Quizzes", (string)null);
                });

            modelBuilder.Entity("Domain.QuizAggregate.Quiz", b =>
                {
                    b.OwnsMany("Domain.QuizAggregate.Entities.Question", "Questions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("QuizId")
                                .HasColumnType("varchar(10)");

                            b1.Property<byte>("CorrectAnswer")
                                .HasColumnType("tinyint");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "QuizId");

                            b1.HasIndex("QuizId");

                            b1.ToTable("Questions", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("QuizId");

                            b1.OwnsMany("Domain.QuizAggregate.Entities.Answer", "Answers", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("QuestionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("QuizId")
                                        .HasColumnType("varchar(10)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "QuestionId", "QuizId");

                                    b2.HasIndex("QuestionId", "QuizId");

                                    b2.ToTable("Answers", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("QuestionId", "QuizId");
                                });

                            b1.Navigation("Answers");
                        });

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}