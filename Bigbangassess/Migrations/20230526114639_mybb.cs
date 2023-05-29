using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigbangassess.Migrations
{
    /// <inheritdoc />
    public partial class mybb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    hotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    hotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelRatings = table.Column<int>(type: "int", nullable: false),
                    hotelContact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.hotelId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.custId);
                    table.ForeignKey(
                        name: "FK_customers_hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "hotelId");
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    roomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_rooms_hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "hotelId");
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    staffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "201, 1"),
                    staffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staffId);
                    table.ForeignKey(
                        name: "FK_staffs_hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "hotelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_hotelId",
                table: "customers",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_hotelId",
                table: "rooms",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_hotelId",
                table: "staffs",
                column: "hotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
