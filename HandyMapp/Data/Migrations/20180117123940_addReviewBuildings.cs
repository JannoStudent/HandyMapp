using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HandyMapp.Data.Migrations
{
    public partial class addReviewBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Obstacles",
                table: "Obstacles");

            migrationBuilder.RenameTable(
                name: "Obstacles",
                newName: "Obstacle");

            migrationBuilder.RenameIndex(
                name: "IX_Obstacles_VectorId",
                table: "Obstacle",
                newName: "IX_Obstacle_VectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obstacle",
                table: "Obstacle",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ReviewBuildings",
                columns: table => new
                {
                    PlaceId = table.Column<string>(nullable: false),
                    AccessibleToilets = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Elevators = table.Column<int>(nullable: false),
                    HallwaysWide = table.Column<int>(nullable: false),
                    LooseTilesOrFloormats = table.Column<int>(nullable: false),
                    Ramps = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Threshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewBuildings", x => x.PlaceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewBuildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Obstacle",
                table: "Obstacle");

            migrationBuilder.RenameTable(
                name: "Obstacle",
                newName: "Obstacles");

            migrationBuilder.RenameIndex(
                name: "IX_Obstacle_VectorId",
                table: "Obstacles",
                newName: "IX_Obstacles_VectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obstacles",
                table: "Obstacles",
                column: "Id");
        }
    }
}
