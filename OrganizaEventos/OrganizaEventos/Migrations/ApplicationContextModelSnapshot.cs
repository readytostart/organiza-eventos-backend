using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("BlogLead");
                });
        }
    }
}
