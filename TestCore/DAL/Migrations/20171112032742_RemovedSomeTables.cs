using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class RemovedSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Experiences_CurrentWorkPlaceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_ApplicationUserId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ApplicationUserId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentWorkPlaceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "CurrentWorkPlaceId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CurrentWorkPlace",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Educations",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousExperience",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentWorkPlace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Educations",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreviousExperience",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Educations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkPlaceId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ApplicationUserId",
                table: "Experiences",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicationUserId",
                table: "Educations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentWorkPlaceId",
                table: "AspNetUsers",
                column: "CurrentWorkPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Experiences_CurrentWorkPlaceId",
                table: "AspNetUsers",
                column: "CurrentWorkPlaceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserId",
                table: "Educations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserId",
                table: "Experiences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
