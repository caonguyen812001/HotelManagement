using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class RoomTypeHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoomType");

            migrationBuilder.DropColumn(
                name: "NumberOfRoom",
                table: "RoomType");

            migrationBuilder.CreateTable(
                name: "RoomTypeMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeCount = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypeMapping_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomTypeMapping_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeMapping_HotelId",
                table: "RoomTypeMapping",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeMapping_RoomTypeId",
                table: "RoomTypeMapping",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypeMapping");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRoom",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
