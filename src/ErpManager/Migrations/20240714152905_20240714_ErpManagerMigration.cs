using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpManager.ERP.Migrations
{
    /// <inheritdoc />
    public partial class _20240714_ErpManagerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Role",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                defaultValueSql: "('')");

            migrationBuilder.AlterColumn<string>(
                name: "RelatedProductId",
                table: "Product",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_TokenId",
                table: "Token",
                column: "TokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleId",
                table: "Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Id",
                table: "Notification",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberId",
                table: "Member",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MailTemplate_MailId",
                table: "MailTemplate",
                column: "MailId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchId",
                table: "Branch",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Token_TokenId",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Role_RoleId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Notification_Id",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Member_MemberId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_MailTemplate_MailId",
                table: "MailTemplate");

            migrationBuilder.DropIndex(
                name: "IX_Branch_BranchId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "RelatedProductId",
                table: "Product",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldDefaultValueSql: "('')");
        }
    }
}
