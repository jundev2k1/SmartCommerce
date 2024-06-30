// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpManager.ERP.Migrations
{
	/// <inheritdoc />
	public partial class ErpManagerMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Branch",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "(('0'))"),
					Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "((''))"),
					Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
					Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((''))"),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					LastChanged = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((''))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Branch_1", x => x.BranchId);
				});

			migrationBuilder.CreateTable(
				name: "Member",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					MemberId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					CardNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					BackupPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Address1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Address2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Address3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Address4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					SubAddress1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					SubAddress2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					SubAddress3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					SubAddress4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					BackupAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
					DelFlg = table.Column<bool>(type: "bit", nullable: false),
					Sex = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(0)"),
					Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
					Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: false),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					LastChanged = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Member_1", x => new { x.BranchId, x.MemberId });
				});

			migrationBuilder.CreateTable(
				name: "Product",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					ProductId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					Images = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, defaultValueSql: "('')"),
					Address1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					Address2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					Address3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					Address4 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					Price1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Price2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Price3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					DisplayPrice = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(0)"),
					Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
					DelFlg = table.Column<bool>(type: "bit", nullable: false),
					Size1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Size2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Size3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					TakeOverId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, defaultValueSql: "('')"),
					EmbeddedLink = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, defaultValueSql: "('')"),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					LastChanged = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product_1", x => new { x.BranchId, x.ProductId });
				});

			migrationBuilder.CreateTable(
				name: "Role",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, defaultValueSql: "('')"),
					Permission = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, defaultValueSql: "('')"),
					Priority = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(0)"),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Role_1", x => new { x.BranchId, x.RoleId });
				});

			migrationBuilder.CreateTable(
				name: "Token",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					TokenId = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
					Type = table.Column<int>(type: "int", nullable: false),
					ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: true),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Token_1", x => new { x.BranchId, x.TokenId });
				});

			migrationBuilder.CreateTable(
				name: "User",
				columns: table => new
				{
					BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					UserId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, defaultValueSql: "('')"),
					PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Address3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Address4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "('')"),
					Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
					DelFlg = table.Column<bool>(type: "bit", nullable: false),
					Sex = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(2)"),
					Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
					DateChanged = table.Column<DateTime>(type: "datetime", nullable: false),
					CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					LastLogin = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					LastChanged = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValueSql: "('')"),
					RoleId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_User_1", x => new { x.BranchId, x.UserId });
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Branch");

			migrationBuilder.DropTable(
				name: "Member");

			migrationBuilder.DropTable(
				name: "Product");

			migrationBuilder.DropTable(
				name: "Role");

			migrationBuilder.DropTable(
				name: "Token");

			migrationBuilder.DropTable(
				name: "User");
		}
	}
}
