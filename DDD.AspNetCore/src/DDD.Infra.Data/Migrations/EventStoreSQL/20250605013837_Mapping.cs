using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infra.Data.Migrations.EventStoreSQL
{
    /// <inheritdoc />
    public partial class Mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "StoredEvent",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "MessageType",
                table: "StoredEvent",
                newName: "Action");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "StoredEvent",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "StoredEvent",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "StoredEvent",
                newName: "MessageType");

            migrationBuilder.AlterColumn<string>(
                name: "MessageType",
                table: "StoredEvent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }
    }
}
