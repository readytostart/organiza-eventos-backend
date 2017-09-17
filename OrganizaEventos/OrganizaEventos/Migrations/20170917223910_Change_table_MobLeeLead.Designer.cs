using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170917223910_Change_table_MobLeeLead")]
    partial class Change_table_MobLeeLead
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrganizaEventosApi.Models.MobLeeLead", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Email")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data");

                    b.Property<string>("IpV4")
                        .IsRequired()
                        .HasColumnName("IpV4")
                        .HasMaxLength(15);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(150);

                    b.HasKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("MobLeeLead");
                });
        }
    }
}
