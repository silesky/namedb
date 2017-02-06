using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NameDb.Model;

namespace server.Migrations
{
    [DbContext(typeof(NameDbContext))]
    partial class NameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("NameDb.Model.Entities.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FirstMeetingId");

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.HasKey("ContactId");

                    b.HasIndex("FirstMeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("NameDb.Model.Entities.FirstMeeting", b =>
                {
                    b.Property<Guid>("FirstMeetingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMeetingDate");

                    b.Property<string>("FirstMeetingName");

                    b.Property<Guid>("UserId");

                    b.HasKey("FirstMeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("FirstMeeting");
                });

            modelBuilder.Entity("NameDb.Model.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NameDb.Model.Entities.Contact", b =>
                {
                    b.HasOne("NameDb.Model.Entities.FirstMeeting", "FirstMeeting")
                        .WithMany("Contacts")
                        .HasForeignKey("FirstMeetingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NameDb.Model.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NameDb.Model.Entities.FirstMeeting", b =>
                {
                    b.HasOne("NameDb.Model.Entities.User", "User")
                        .WithMany("FirstMeeting")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
