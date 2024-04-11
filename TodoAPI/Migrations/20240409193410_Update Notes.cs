using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
	public partial class UpdateNotes : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Notes",
				type: "nvarchar(200)",
				maxLength: 200,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(100)",
				oldMaxLength: 100);

			migrationBuilder.AddColumn<bool>(
				name: "Active",
				table: "Notes",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Active",
				table: "Notes");

			migrationBuilder.DropColumn(
				name: "DateCreated",
				table: "Notes");

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Notes",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(200)",
				oldMaxLength: 200);
		}
	}
}
