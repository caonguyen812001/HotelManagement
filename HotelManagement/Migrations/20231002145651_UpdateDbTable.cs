using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class UpdateDbTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenityMapping_RoomTypes_RoomTypeId",
                table: "AmenityMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHotel_Booking_BookingsId",
                table: "BookingHotel");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Booking_BookingId",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenityMapping",
                table: "AmenityMapping");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "AmenityMapping",
                newName: "AmenityMappings");

            migrationBuilder.RenameIndex(
                name: "IX_AmenityMapping_RoomTypeId",
                table: "AmenityMappings",
                newName: "IX_AmenityMappings_RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenityMappings",
                table: "AmenityMappings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityMappings_RoomTypes_RoomTypeId",
                table: "AmenityMappings",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHotel_Bookings_BookingsId",
                table: "BookingHotel",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Bookings_BookingId",
                table: "RoomTypes",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmenityMappings_RoomTypes_RoomTypeId",
                table: "AmenityMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHotel_Bookings_BookingsId",
                table: "BookingHotel");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Bookings_BookingId",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenityMappings",
                table: "AmenityMappings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "AmenityMappings",
                newName: "AmenityMapping");

            migrationBuilder.RenameIndex(
                name: "IX_AmenityMappings_RoomTypeId",
                table: "AmenityMapping",
                newName: "IX_AmenityMapping_RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenityMapping",
                table: "AmenityMapping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmenityMapping_RoomTypes_RoomTypeId",
                table: "AmenityMapping",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHotel_Booking_BookingsId",
                table: "BookingHotel",
                column: "BookingsId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Booking_BookingId",
                table: "RoomTypes",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }
    }
}
