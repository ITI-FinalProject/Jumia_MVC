using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.MVC.Migrations
{
    public partial class upadfavouritItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavoriteItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_UserId",
                table: "FavoriteItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_AspNetUsers_UserId",
                table: "FavoriteItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_AspNetUsers_UserId",
                table: "FavoriteItems");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteItems_UserId",
                table: "FavoriteItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteItems");
        }
    }
}
