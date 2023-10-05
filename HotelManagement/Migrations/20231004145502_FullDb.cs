using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class FullDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Hotels_HotelId",
                table: "RoomType");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_HotelId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomType");

            migrationBuilder.CreateTable(
                name: "HotelRoomType",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomType", x => new { x.HotelId, x.RoomTypesId });
                    table.ForeignKey(
                        name: "FK_HotelRoomType_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoomType_RoomType_RoomTypesId",
                        column: x => x.RoomTypesId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomType_RoomTypesId",
                table: "HotelRoomType",
                column: "RoomTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoomType");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "RoomType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_HotelId",
                table: "RoomType",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Hotels_HotelId",
                table: "RoomType",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
