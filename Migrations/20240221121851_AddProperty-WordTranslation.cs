using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtarioLearning.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyWordTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WordTranslation",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WordTranslation",
                table: "Words");
        }
    }
}
