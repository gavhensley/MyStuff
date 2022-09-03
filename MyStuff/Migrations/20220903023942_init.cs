using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStuff.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacementNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacementNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[] { 1, "", "Bedroom" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[] { 2, "", "Kitchen" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[] { 3, "", "Bathroom" });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Image", "LocationId", "Name", "PlacementNotes" },
                values: new object[] { 1, "", 1, "Bed", "For items placed on the bed" });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Image", "LocationId", "Name", "PlacementNotes" },
                values: new object[] { 2, "", 2, "Silverware Drawer", "" });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Image", "LocationId", "Name", "PlacementNotes" },
                values: new object[] { 3, "", 3, "Cabinet", "" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Image", "Name", "PlacementNotes", "StorageId" },
                values: new object[] { 1, "Main pillow", "", "Pillow", "At the head of the bed", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Image", "Name", "PlacementNotes", "StorageId" },
                values: new object[] { 2, "Forks", "", "Forks", "In the silverware drawer", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_StorageId",
                table: "Items",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_LocationId",
                table: "Storages",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
