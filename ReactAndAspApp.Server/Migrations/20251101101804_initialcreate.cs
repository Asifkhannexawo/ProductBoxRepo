using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactAndAspApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Regular" },
                    { 2, "Premium" },
                    { 3, "Corporate" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "CustomerTypeId", "Description", "LastUpdated", "Name", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Springfield", 1, "First sample customer", new DateTime(2025, 11, 1, 10, 17, 54, 915, DateTimeKind.Utc).AddTicks(4708), "Alice Smith", "IL", "62701" },
                    { 2, "456 Corporate Blvd", "Chicago", 3, "Corporate client example", new DateTime(2025, 11, 1, 10, 17, 54, 915, DateTimeKind.Utc).AddTicks(5547), "Acme Corp", "IL", "60601" },
                    { 3, "789 Elm St", "Evanston", 2, "Premium customer", new DateTime(2025, 11, 1, 10, 17, 54, 915, DateTimeKind.Utc).AddTicks(5553), "Bob Johnson", "IL", "60201" },
                    { 4, "22 Oak Ave", "Naperville", 1, null, new DateTime(2025, 11, 1, 10, 17, 54, 915, DateTimeKind.Utc).AddTicks(5559), "Cathy Lee", "IL", "60540" },
                    { 5, "100 Market St", "Aurora", 3, "Another corporate", new DateTime(2025, 11, 1, 10, 17, 54, 915, DateTimeKind.Utc).AddTicks(5565), "Delta LLC", "IL", "60505" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
