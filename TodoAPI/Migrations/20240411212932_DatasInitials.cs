using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
	public partial class DatasInitials : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 11, 21, 29, 32, 381, DateTimeKind.Utc).AddTicks(985),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 9, 22, 12, 54, 301, DateTimeKind.Utc).AddTicks(359));

			migrationBuilder.InsertData(
				table: "Notes",
				columns: new[] { "Id", "Description" },
				values: new object[,]
				{
					{ 1, "Description_32_01" },
					{ 2, "Description_32_02" },
					{ 3, "Description_32_03" },
					{ 4, "Description_32_04" },
					{ 5, "Description_32_05" }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Notes",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Notes",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Notes",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "Notes",
				keyColumn: "Id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "Notes",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateCreated",
				table: "Notes",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(2024, 4, 9, 22, 12, 54, 301, DateTimeKind.Utc).AddTicks(359),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldDefaultValue: new DateTime(2024, 4, 11, 21, 29, 32, 381, DateTimeKind.Utc).AddTicks(985));
		}
	}
}
