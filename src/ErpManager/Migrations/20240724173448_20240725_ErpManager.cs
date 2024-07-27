using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpManager.ERP.Migrations
{
    /// <inheritdoc />
    public partial class _20240725_ErpManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageDefault",
                table: "Role",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldDefaultValueSql: "('')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageDefault",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "('')");
        }
    }
}
