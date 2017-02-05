﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstMeeting",
                columns: table => new
                {
                    FirstMeetingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    FirstMeetingDate = table.Column<string>(nullable: true),
                    FirstMeetingName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstMeeting", x => x.FirstMeetingId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Email = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    FirstMeetingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_FirstMeeting_FirstMeetingId",
                        column: x => x.FirstMeetingId,
                        principalTable: "FirstMeeting",
                        principalColumn: "FirstMeetingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_FirstMeetingId",
                table: "Contact",
                column: "FirstMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "FirstMeeting");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
