using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ConsilierInteligent.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectiuni_Tip_Raport",
                columns: table => new
                {
                    id_sectiune_tip_Raport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_sectiune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scurta_descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectiuni_Tip_Raport", x => x.id_sectiune_tip_Raport);
                });

            migrationBuilder.CreateTable(
                name: "Solutie",
                columns: table => new
                {
                    id_solutie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_solutie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutie", x => x.id_solutie);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    id_utilizator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    parola = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.id_utilizator);
                });

            migrationBuilder.CreateTable(
                name: "Raport",
                columns: table => new
                {
                    id_raport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_solutie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raport", x => x.id_raport);
                    table.ForeignKey(
                        name: "FK_Raport_Solutie_id_solutie",
                        column: x => x.id_solutie,
                        principalTable: "Solutie",
                        principalColumn: "id_solutie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consilier",
                columns: table => new
                {
                    id_consilier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_utilizator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consilier", x => x.id_consilier);
                    table.ForeignKey(
                        name: "FK_Consilier_Utilizator_id_utilizator",
                        column: x => x.id_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id_utilizator");
                });

            migrationBuilder.CreateTable(
                name: "Elev",
                columns: table => new
                {
                    id_elev = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_utilizator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elev", x => x.id_elev);
                    table.ForeignKey(
                        name: "FK_Elev_Utilizator_id_utilizator",
                        column: x => x.id_utilizator,
                        principalTable: "Utilizator",
                        principalColumn: "id_utilizator");
                });

            migrationBuilder.CreateTable(
                name: "Sectiuni_Raport",
                columns: table => new
                {
                    id_sectiune_Raport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_raport = table.Column<int>(type: "int", nullable: false),
                    id_sectiune_tip_Raport = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectiuni_Raport", x => x.id_sectiune_Raport);
                    table.ForeignKey(
                        name: "FK_Sectiuni_Raport_Raport_id_raport",
                        column: x => x.id_raport,
                        principalTable: "Raport",
                        principalColumn: "id_raport",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sectiuni_Raport_Sectiuni_Tip_Raport_id_sectiune_tip_Raport",
                        column: x => x.id_sectiune_tip_Raport,
                        principalTable: "Sectiuni_Tip_Raport",
                        principalColumn: "id_sectiune_tip_Raport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chestionar",
                columns: table => new
                {
                    id_chestionar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire_test = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_consilier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chestionar", x => x.id_chestionar);
                    table.ForeignKey(
                        name: "FK_Chestionar_Consilier_id_consilier",
                        column: x => x.id_consilier,
                        principalTable: "Consilier",
                        principalColumn: "id_consilier");
                });

            migrationBuilder.CreateTable(
                name: "Intrebare",
                columns: table => new
                {
                    id_intrebare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formulare_intrebare = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_chestionar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrebare", x => x.id_intrebare);
                    table.ForeignKey(
                        name: "FK_Intrebare_Chestionar_id_chestionar",
                        column: x => x.id_chestionar,
                        principalTable: "Chestionar",
                        principalColumn: "id_chestionar");
                });

            migrationBuilder.CreateTable(
                name: "Solutii_Training",
                columns: table => new
                {
                    id_solutii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intrebare_1 = table.Column<int>(type: "int", nullable: false),
                    intrebare_2 = table.Column<int>(type: "int", nullable: false),
                    intrebare_3 = table.Column<int>(type: "int", nullable: false),
                    intrebare_4 = table.Column<int>(type: "int", nullable: false),
                    intrebare_5 = table.Column<int>(type: "int", nullable: false),
                    intrebare_6 = table.Column<int>(type: "int", nullable: false),
                    intrebare_7 = table.Column<int>(type: "int", nullable: false),
                    intrebare_8 = table.Column<int>(type: "int", nullable: false),
                    intrebare_9 = table.Column<int>(type: "int", nullable: false),
                    intrebare_10 = table.Column<int>(type: "int", nullable: false),
                    intrebare_11 = table.Column<int>(type: "int", nullable: false),
                    intrebare_12 = table.Column<int>(type: "int", nullable: false),
                    id_chestionar = table.Column<int>(type: "int", nullable: true),
                    id_solutie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutii_Training", x => x.id_solutii);
                    table.ForeignKey(
                        name: "FK_Solutii_Training_Chestionar_id_chestionar",
                        column: x => x.id_chestionar,
                        principalTable: "Chestionar",
                        principalColumn: "id_chestionar");
                    table.ForeignKey(
                        name: "FK_Solutii_Training_Solutie_id_solutie",
                        column: x => x.id_solutie,
                        principalTable: "Solutie",
                        principalColumn: "id_solutie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raspuns",
                columns: table => new
                {
                    id_raspuns = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_intrebare = table.Column<int>(type: "int", nullable: true),
                    Intrebareid_intrebare = table.Column<int>(type: "int", nullable: false),
                    ResponseText = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspuns", x => x.id_raspuns);
                    table.ForeignKey(
                        name: "FK_Raspuns_Intrebare_Intrebareid_intrebare",
                        column: x => x.Intrebareid_intrebare,
                        principalTable: "Intrebare",
                        principalColumn: "id_intrebare",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chestionar_id_consilier",
                table: "Chestionar",
                column: "id_consilier");

            migrationBuilder.CreateIndex(
                name: "IX_Consilier_id_utilizator",
                table: "Consilier",
                column: "id_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Elev_id_utilizator",
                table: "Elev",
                column: "id_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Intrebare_id_chestionar",
                table: "Intrebare",
                column: "id_chestionar");

            migrationBuilder.CreateIndex(
                name: "IX_Raport_id_solutie",
                table: "Raport",
                column: "id_solutie");

            migrationBuilder.CreateIndex(
                name: "IX_Raspuns_Intrebareid_intrebare",
                table: "Raspuns",
                column: "Intrebareid_intrebare");

            migrationBuilder.CreateIndex(
                name: "IX_Sectiuni_Raport_id_raport",
                table: "Sectiuni_Raport",
                column: "id_raport");

            migrationBuilder.CreateIndex(
                name: "IX_Sectiuni_Raport_id_sectiune_tip_Raport",
                table: "Sectiuni_Raport",
                column: "id_sectiune_tip_Raport");

            migrationBuilder.CreateIndex(
                name: "IX_Solutii_Training_id_chestionar",
                table: "Solutii_Training",
                column: "id_chestionar");

            migrationBuilder.CreateIndex(
                name: "IX_Solutii_Training_id_solutie",
                table: "Solutii_Training",
                column: "id_solutie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elev");

            migrationBuilder.DropTable(
                name: "Raspuns");

            migrationBuilder.DropTable(
                name: "Sectiuni_Raport");

            migrationBuilder.DropTable(
                name: "Solutii_Training");

            migrationBuilder.DropTable(
                name: "Intrebare");

            migrationBuilder.DropTable(
                name: "Raport");

            migrationBuilder.DropTable(
                name: "Sectiuni_Tip_Raport");

            migrationBuilder.DropTable(
                name: "Chestionar");

            migrationBuilder.DropTable(
                name: "Solutie");

            migrationBuilder.DropTable(
                name: "Consilier");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
