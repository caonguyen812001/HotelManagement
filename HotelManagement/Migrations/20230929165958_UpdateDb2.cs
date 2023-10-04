using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class UpdateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Hotels_HotelId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_RoomTypes_RomTypeId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_HotelId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_RomTypeId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "RomTypeId",
                table: "Booking");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "RoomTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingHotel",
                columns: table => new
                {
                    BookingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHotel", x => new { x.BookingsId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_BookingHotel_Booking_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingHotel_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_BookingId",
                table: "RoomTypes",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotel_HotelId",
                table: "BookingHotel",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Booking_BookingId",
                table: "RoomTypes",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Booking_BookingId",
                table: "RoomTypes");

            migrationBuilder.DropTable(
                name: "BookingHotel");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_BookingId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "RoomTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "RomTypeId",
                table: "Booking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HotelId",
                table: "Booking",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RomTypeId",
                table: "Booking",
                column: "RomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Hotels_HotelId",
                table: "Booking",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_RoomTypes_RomTypeId",
                table: "Booking",
                column: "RomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
