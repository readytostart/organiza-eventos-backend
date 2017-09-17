using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170917221730_Create_table_Lead")]
    partial class Create_table_Lead
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrganizaEventosApi.Models.BlogLead", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(150);

                    b.Property<string>("IpV4")
                        .IsRequired()
                        .HasColumnName("IpV4")
                        .HasMaxLength(15);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("BlogLead");
                });

            modelBuilder.Entity("OrganizaEventosApi.Models.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(150);

                    b.Property<string>("IpV4")
                        .IsRequired()
                        .HasColumnName("IpV4")
                        .HasMaxLength(15);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Lead");
                });
        }
    }
}
