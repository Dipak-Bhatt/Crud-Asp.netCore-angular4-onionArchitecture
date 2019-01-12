﻿// <auto-generated />
using System;
using DB.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180921171024_dbcrud")]
    partial class dbcrud
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Entity.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descriptions")
                        .IsRequired();

                    b.Property<string>("ImageName");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("PId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Testimonial");
                });
#pragma warning restore 612, 618
        }
    }
}
