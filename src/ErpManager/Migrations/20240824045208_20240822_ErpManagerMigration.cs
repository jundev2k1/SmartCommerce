using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpManager.Manager.Migrations
{
    /// <inheritdoc />
    public partial class _20240822_ErpManagerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Product",
                type: "nvarchar(4000)",
                nullable: true,
                defaultValueSql: "('')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Product");
        }
    }
}
