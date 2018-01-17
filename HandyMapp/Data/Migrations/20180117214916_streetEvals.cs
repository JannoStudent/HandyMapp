using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandyMapp.Data.Migrations
{
    public partial class streetEvals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "aid",
                table: "StreetEvalModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "streetname",
                table: "StreetEvalModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "streetname",
                table: "StreetEvalModels");

            migrationBuilder.AlterColumn<string>(
                name: "aid",
                table: "StreetEvalModels",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
