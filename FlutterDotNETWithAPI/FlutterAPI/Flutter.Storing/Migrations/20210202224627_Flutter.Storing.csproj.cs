using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flutter.Storing.Migrations
{
    public partial class FlutterStoringcsproj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AUserEntityId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AUserEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AUserEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Posts");

            migrationBuilder.AddColumn<long>(
                name: "AUserEntityId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Posts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AUserEntityId",
                table: "Posts",
                column: "AUserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AUserEntityId",
                table: "Posts",
                column: "AUserEntityId",
                principalTable: "Users",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
