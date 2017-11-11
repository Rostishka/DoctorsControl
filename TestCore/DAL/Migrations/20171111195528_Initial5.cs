using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PatientEntityId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
