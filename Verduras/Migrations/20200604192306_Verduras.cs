using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Verduras.Migrations
{
    public partial class Verduras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Cantidad = table.Column<double>(nullable: false),
                    Costo = table.Column<double>(nullable: false),
                    Margen = table.Column<double>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Unidad = table.Column<string>(nullable: true),
                    Proveedor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendedor = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Utilidad = table.Column<double>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Users_Vendedor",
                        column: x => x.Vendedor,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venta = table.Column<int>(nullable: false),
                    Producto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendidos_Productos_Producto",
                        column: x => x.Producto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendidos_Ventas_Venta",
                        column: x => x.Venta,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_Producto",
                table: "Vendidos",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_Venta",
                table: "Vendidos",
                column: "Venta");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Vendedor",
                table: "Ventas",
                column: "Vendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
