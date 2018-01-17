using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandyMapp.Data.Migrations
{
    public partial class updateReviewBuildingsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewBuildings",
                table: "ReviewBuildings");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "ReviewBuildings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReviewBuildings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewBuildings",
                table: "ReviewBuildings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewBuildings",
                table: "ReviewBuildings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReviewBuildings");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "ReviewBuildings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewBuildings",
                table: "ReviewBuildings",
                column: "PlaceId");
        }
    }
}
