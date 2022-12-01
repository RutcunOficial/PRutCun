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
                    NombreCalle = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoInteres", x => x.PkPunto);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
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
                    FkRol = table.Column<int>(type: "int", nullable: true),
                    RolPkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.PkUser);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_RolPkRol",
                        column: x => x.RolPkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trasporte",
                columns: table => new
                {
                    PkTransporte = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Trasporte", x => x.PkTransporte);
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
                    FkTransporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalleTransitada", x => new { x.FkCalle, x.FkTransporte });
                    table.ForeignKey(
                        name: "FK_CalleTransitada_Calle_FkCalle",
                        column: x => x.FkCalle,
                        principalTable: "Calle",
                        principalColumn: "PkCalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalleTransitada_Trasporte_FkTransporte",
                        column: x => x.FkTransporte,
                        principalTable: "Trasporte",
                        principalColumn: "PkTransporte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mapas",
                columns: table => new
                {
                    PkMapas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fktransportes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapas", x => x.PkMapas);
                    table.ForeignKey(
                        name: "FK_Mapas_Trasporte_Fktransportes",
                        column: x => x.Fktransportes,
                        principalTable: "Trasporte",
                        principalColumn: "PkTransporte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuntoTransitado",
                columns: table => new
                {
                    FkPunto = table.Column<int>(type: "int", nullable: false),
                    FkTransporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoTransitado", x => new { x.FkPunto, x.FkTransporte });
                    table.ForeignKey(
                        name: "FK_PuntoTransitado_PuntoInteres_FkPunto",
                        column: x => x.FkPunto,
                        principalTable: "PuntoInteres",
                        principalColumn: "PkPunto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoTransitado_Trasporte_FkTransporte",
                        column: x => x.FkTransporte,
                        principalTable: "Trasporte",
                        principalColumn: "PkTransporte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalleTransitada_FkTransporte",
                table: "CalleTransitada",
                column: "FkTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_Fktransportes",
                table: "Mapas",
                column: "Fktransportes");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoTransitado_FkTransporte",
                table: "PuntoTransitado",
                column: "FkTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_Trasporte_FkTipo",
                table: "Trasporte",
                column: "FkTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolPkRol",
                table: "Usuario",
                column: "RolPkRol");
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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TipoTrasporte");
        }
    }
}
