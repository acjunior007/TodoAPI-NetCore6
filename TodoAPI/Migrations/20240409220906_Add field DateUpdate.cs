using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
	public partial class AddfieldDateUpdate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 9, 22, 9, 6, 851, DateTimeKind.Utc).AddTicks(8247),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 9, 19, 38, 28, 477, DateTimeKind.Utc).AddTicks(2222));

			migrationBuilder.AddColumn<DateTime>(
				name: "DateUpdated",
				table: "Notes",
				type: "datetime2",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DateUpdated",
				table: "Notes");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 9, 19, 38, 28, 477, DateTimeKind.Utc).AddTicks(2222),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 9, 22, 9, 6, 851, DateTimeKind.Utc).AddTicks(8247));
		}
	}
}
