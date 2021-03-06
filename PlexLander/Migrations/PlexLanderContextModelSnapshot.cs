﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PlexLander.Data;
using System;

namespace PlexLander.Migrations
{
    [DbContext(typeof(PlexLanderContext))]
    partial class PlexLanderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlexLander.Models.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("PlexLander.Models.PlexAuthentication", b =>
                {
                    b.Property<string>("Email");

                    b.Property<string>("Token");

                    b.Property<DateTime>("SessionStart");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Username");

                    b.HasKey("Email", "Token");

                    b.ToTable("PlexSessions");
                });

            modelBuilder.Entity("PlexLander.Models.PlexServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endpoint");

                    b.Property<string>("Hostname");

                    b.Property<string>("PlexAuthenticationEmail");

                    b.Property<string>("PlexAuthenticationToken");

                    b.Property<int>("Port");

                    b.HasKey("Id");

                    b.HasIndex("PlexAuthenticationEmail", "PlexAuthenticationToken");

                    b.ToTable("PlexServer");
                });

            modelBuilder.Entity("PlexLander.Models.PlexServer", b =>
                {
                    b.HasOne("PlexLander.Models.PlexAuthentication")
                        .WithMany("Servers")
                        .HasForeignKey("PlexAuthenticationEmail", "PlexAuthenticationToken");
                });
#pragma warning restore 612, 618
        }
    }
}
