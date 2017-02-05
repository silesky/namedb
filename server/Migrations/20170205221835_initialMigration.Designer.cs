using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NameDb.Model;

namespace server.Migrations
{
    [DbContext(typeof(NameDbContext))]
    [Migration("20170205221835_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("NameDb.Model.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstMeetingId");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("ContactId");

                    b.HasIndex("FirstMeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("NameDb.Model.FirstMeeting", b =>
                {
                    b.Property<int>("FirstMeetingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMeetingDate");

                    b.Property<string>("FirstMeetingName");

                    b.Property<int>("UserId");

                    b.HasKey("FirstMeetingId");

                    b.ToTable("FirstMeeting");
                });

            modelBuilder.Entity("NameDb.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Email");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NameDb.Model.Contact", b =>
                {
                    b.HasOne("NameDb.Model.FirstMeeting", "FirstMeeting")
                        .WithMany("Contacts")
                        .HasForeignKey("FirstMeetingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NameDb.Model.User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
