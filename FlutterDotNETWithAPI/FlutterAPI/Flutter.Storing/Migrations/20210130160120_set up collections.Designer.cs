﻿// <auto-generated />
using System;
using Flutter.Storing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flutter.Storing.Migrations
{
    [DbContext(typeof(FlutterContext))]
    [Migration("20210130160120_set up collections")]
    partial class setupcollections
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Flutter.Domain.Models.AUser", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flutter.Domain.Models.Post", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AUserEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CommentOfId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<long>("LikeScore")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("AUserEntityId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Flutter.Domain.Models.Tag", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<long>("TagIdsEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaggedPostsEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("TagIdsEntityId", "TaggedPostsEntityId");

                    b.HasIndex("TaggedPostsEntityId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("Flutter.Domain.Models.Post", b =>
                {
                    b.HasOne("Flutter.Domain.Models.AUser", null)
                        .WithMany("Posts")
                        .HasForeignKey("AUserEntityId");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("Flutter.Domain.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagIdsEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flutter.Domain.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("TaggedPostsEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Flutter.Domain.Models.AUser", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
