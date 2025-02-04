using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_web_api.Migrations
{
    /// <inheritdoc />
    public partial class updatedcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conent",
                table: "Comments",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Conent");
        }
    }
}
