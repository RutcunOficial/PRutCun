using Microsoft.EntityFrameworkCore.Migrations;

namespace PRutCun.Migrations
{
    public partial class Rutcun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calle",
                columns: table => new
                {
                    PkCalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calle", x => x.PkCalle);
                });

            migrationBuilder.CreateTable(
                name: "PuntoInteres",
                columns: table => new
                {
                    PkPunto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoInteres", x => x.PkPunto);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoTrasporte",
                columns: table => new
                {
                    PkTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTrasporte", x => x.PkTipo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    PkUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.PkUser);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Rol",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trasporte",
                columns: table => new
                {
                    PkTrasporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FkTipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasporte", x => x.PkTrasporte);
                    table.ForeignKey(
                        name: "FK_Trasporte_TipoTrasporte_FkTipo",
                        column: x => x.FkTipo,
                        principalTable: "TipoTrasporte",
                        principalColumn: "PkTipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalleTransitada",
                columns: table => new
                {
                    FkCalle = table.Column<int>(type: "int", nullable: false),
                    FkTrasporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalleTransitada", x => new { x.FkCalle, x.FkTrasporte });
                    table.ForeignKey(
                        name: "FK_CalleTransitada_Calle_FkCalle",
                        column: x => x.FkCalle,
                        principalTable: "Calle",
                        principalColumn: "PkCalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalleTransitada_Trasporte_FkTrasporte",
                        column: x => x.FkTrasporte,
                        principalTable: "Trasporte",
                        principalColumn: "PkTrasporte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mapas",
                columns: table => new
                {
                    PkMapas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkTrasporte = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapas", x => x.PkMapas);
                    table.ForeignKey(
                        name: "FK_Mapas_Trasporte_FkTrasporte",
                        column: x => x.FkTrasporte,
                        principalTable: "Trasporte",
                        principalColumn: "PkTrasporte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuntoTransitado",
                columns: table => new
                {
                    FkPunto = table.Column<int>(type: "int", nullable: false),
                    FkTrasporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoTransitado", x => new { x.FkPunto, x.FkTrasporte });
                    table.ForeignKey(
                        name: "FK_PuntoTransitado_PuntoInteres_FkPunto",
                        column: x => x.FkPunto,
                        principalTable: "PuntoInteres",
                        principalColumn: "PkPunto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoTransitado_Trasporte_FkTrasporte",
                        column: x => x.FkTrasporte,
                        principalTable: "Trasporte",
                        principalColumn: "PkTrasporte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalleTransitada_FkTrasporte",
                table: "CalleTransitada",
                column: "FkTrasporte");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_FkTrasporte",
                table: "Mapas",
                column: "FkTrasporte");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoTransitado_FkTrasporte",
                table: "PuntoTransitado",
                column: "FkTrasporte");

            migrationBuilder.CreateIndex(
                name: "IX_Trasporte_FkTipo",
                table: "Trasporte",
                column: "FkTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FkRol",
                table: "Usuario",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalleTransitada");

            migrationBuilder.DropTable(
                name: "Mapas");

            migrationBuilder.DropTable(
                name: "PuntoTransitado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Calle");

            migrationBuilder.DropTable(
                name: "PuntoInteres");

            migrationBuilder.DropTable(
                name: "Trasporte");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoTrasporte");
        }
    }
}
