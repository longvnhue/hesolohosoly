using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gitEF.Migrations
{
    /// <inheritdoc />
    public partial class NhamNham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lớp sinh hoạt",
                columns: table => new
                {
                    ID_Lop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tênlớp = table.Column<string>(name: "Tên lớp", type: "nvarchar(max)", nullable: false),
                    Khoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lớp sinh hoạt", x => x.ID_Lop);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sinh Viên",
                columns: table => new
                {
                    MSSV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DTB = table.Column<double>(type: "float", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    ID_Lop = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinh Viên", x => x.MSSV);
                    table.ForeignKey(
                        name: "FK_Sinh Viên_Lớp sinh hoạt_ID_Lop",
                        column: x => x.ID_Lop,
                        principalTable: "Lớp sinh hoạt",
                        principalColumn: "ID_Lop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sinh Viên_Ranks_ID",
                        column: x => x.ID,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinh Viên_ID",
                table: "Sinh Viên",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sinh Viên_ID_Lop",
                table: "Sinh Viên",
                column: "ID_Lop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinh Viên");

            migrationBuilder.DropTable(
                name: "Lớp sinh hoạt");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
