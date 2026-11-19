using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoCatalogMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotographerAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Photographer",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotographerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    PhotographerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.PhotographerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotographerId",
                table: "Photos",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "PhotographerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotographerId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Photos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photographer",
                table: "Photos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
