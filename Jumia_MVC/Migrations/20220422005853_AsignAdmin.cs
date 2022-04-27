using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.MVC.Migrations
{
    public partial class AsignAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert Into [dbo].[AspNetUserRoles] (UserId,RoleId) select '570f613a-fa24-4a9c-b832-ad75f3739046',Id from [dbo].[AspNetRoles]");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[AspNetUserRoles] where USERID ='570f613a-fa24-4a9c-b832-ad75f3739046'");

        }
    }
}
