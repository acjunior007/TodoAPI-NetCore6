using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
	public partial class RemovefieldDateUpdate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DateUpdated",
				table: "Notes");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 9, 22, 12, 54, 301, DateTimeKind.Utc).AddTicks(359),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 9, 22, 9, 6, 851, DateTimeKind.Utc).AddTicks(8247));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 9, 22, 9, 6, 851, DateTimeKind.Utc).AddTicks(8247),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 9, 22, 12, 54, 301, DateTimeKind.Utc).AddTicks(359));

			migrationBuilder.AddColumn<DateTime>(
				name: "DateUpdated",
				table: "Notes",
				type: "datetime2",
				nullable: true);
		}
	}
}
