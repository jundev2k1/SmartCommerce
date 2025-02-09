using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCommerce.Manager.Migrations
{
    /// <inheritdoc />
    public partial class _20240824_ErpManagerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId10",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId2",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId3",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId4",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId5",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId6",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId7",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId8",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId9",
                table: "Product",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, defaultValueSql: "('')"),
                    ParentCategoryId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "('root')"),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
                    LastChanged = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_1", x => new { x.BranchId, x.CategoryId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId10",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId4",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId5",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId6",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId7",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId8",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId9",
                table: "Product");
        }
    }
}
