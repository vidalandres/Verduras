using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Verduras.Migrations
{
    public partial class Verduras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Vendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentId = table.Column<int>(nullable: true),
                    Venta = table.Column<int>(nullable: false),
                    Producto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendedor = table.Column<string>(nullable: true),
                    ProductoId = table.Column<int>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Utilidad = table.Column<double>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_Vendedor",
                        column: x => x.Vendedor,
                        principalTable: "Usuarios",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Proveedor = table.Column<string>(nullable: true),
                    Producto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Ventas_Producto",
                        column: x => x.Producto,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Producto",
                table: "Productos",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_Producto",
                table: "Vendidos",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_VentId",
                table: "Vendidos",
                column: "VentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ProductoId",
                table: "Ventas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Vendedor",
                table: "Ventas",
                column: "Vendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendidos_Ventas_VentId",
                table: "Vendidos",
                column: "VentId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendidos_Productos_Producto",
                table: "Vendidos",
                column: "Producto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Productos_ProductoId",
                table: "Ventas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_Producto",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Vendidos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
