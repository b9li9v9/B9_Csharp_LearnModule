using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Cars");
        }
    }
}
