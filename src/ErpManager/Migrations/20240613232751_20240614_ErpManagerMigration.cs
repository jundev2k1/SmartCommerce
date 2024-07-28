// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpManager.Manager.Migrations
{
	/// <inheritdoc />
	public partial class _20240614_ErpManagerMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "RelatedProductId",
				table: "Product",
				type: "nvarchar(4000)",
				maxLength: 4000,
				nullable: false);

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateChanged",
				table: "Member",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime");

			migrationBuilder.CreateTable(
				name: "MailTemplate",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					MailId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
					Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					Body = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
					From = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
					To = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
					Cc = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
					Bcc = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
					Status = table.Column<int>(type: "int", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MailTemplate_1", x => new { x.BranchId, x.MailId });
				});

			migrationBuilder.CreateTable(
				name: "Notification",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
					Path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					Type = table.Column<int>(type: "int", nullable: false),
					Priority = table.Column<int>(type: "int", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Notification_1", x => new { x.BranchId, x.Id, x.UserId });
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "MailTemplate");

			migrationBuilder.DropTable(
				name: "Notification");

			migrationBuilder.DropColumn(
				name: "RelatedProductId",
				table: "Product");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateChanged",
				table: "Member",
				type: "datetime",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);
		}
	}
}
