using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ebebul.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Birthplace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Length = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midwife", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthdate", "Birthplace", "CategoryId", "CreatDate", "Email", "Gender", "IdentityNum", "Length", "Location", "Name", "Password", "Surname", "UpdateDate", "UserName", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5555), "Ümraniye", 1, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5563), "nurullahguguk@gmail.com", 2, "40282523972", 180, "Beykoz", "Nurullah", "1234", "Guguk", null, "nurullahggk", 102 },
                    { 2, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5565), "Çekmeköy", 2, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5566), "beyzayldrm@gmail.com", 1, "10325523928", 163, "Pendik", "Beyza", "1234", "Yıldırım", null, "beyzayldrm", 65 },
                    { 3, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5567), "Bursa", 3, new DateTime(2022, 11, 29, 2, 43, 26, 904, DateTimeKind.Local).AddTicks(5567), "sencan@gmail.com", 1, "10586954732", 155, "Maltepe", "Sena", "1234", "Can", null, "sencan", 65 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryId",
                table: "Users",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
