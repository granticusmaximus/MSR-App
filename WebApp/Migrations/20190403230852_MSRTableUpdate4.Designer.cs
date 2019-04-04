﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp;

namespace WebApp.Migrations
{
    [DbContext(typeof(MSRDbContext))]
    [Migration("20190403230852_MSRTableUpdate4")]
    partial class MSRTableUpdate4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Analyst", b =>
                {
                    b.Property<int>("BAID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BAFName");

                    b.Property<string>("BALName");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.HasKey("BAID");

                    b.ToTable("Analysts");
                });

            modelBuilder.Entity("WebApp.Models.AppList", b =>
                {
                    b.Property<int>("AppID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppName");

                    b.Property<string>("AppNotes");

                    b.Property<int>("AssignedBA");

                    b.Property<int>("AssignedDev");

                    b.Property<string>("POC");

                    b.Property<string>("POCEmail");

                    b.Property<string>("Telephone");

                    b.HasKey("AppID");

                    b.HasIndex("AssignedBA");

                    b.HasIndex("AssignedDev");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("WebApp.Models.Developer", b =>
                {
                    b.Property<int>("DevID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DevFName");

                    b.Property<string>("DevLName");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.HasKey("DevID");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("WebApp.Models.Employee", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<string>("Phone");

                    b.HasKey("EmpID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApp.Models.MSRTask", b =>
                {
                    b.Property<int>("MsrID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppsAppID");

                    b.Property<int>("AssignedAppID");

                    b.Property<int>("AssignedEmpID");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("MSRNote");

                    b.Property<string>("MSRtitle");

                    b.HasKey("MsrID");

                    b.HasIndex("AppsAppID");

                    b.HasIndex("AssignedEmpID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebApp.Models.AppList", b =>
                {
                    b.HasOne("WebApp.Models.Analyst", "Analyst")
                        .WithMany()
                        .HasForeignKey("AssignedBA")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("AssignedDev")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp.Models.MSRTask", b =>
                {
                    b.HasOne("WebApp.Models.AppList", "Apps")
                        .WithMany()
                        .HasForeignKey("AppsAppID");

                    b.HasOne("WebApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("AssignedEmpID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
