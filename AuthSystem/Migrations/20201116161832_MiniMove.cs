using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class MiniMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    CodiceArticolo = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.CodiceArticolo);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentriDiLavoro",
                columns: table => new
                {
                    CodiceCentroDiLavoro = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Descrzione = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentriDiLavoro", x => x.CodiceCentroDiLavoro);
                });

            migrationBuilder.CreateTable(
                name: "Postazioni",
                columns: table => new
                {
                    IdPostazione = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePostazione = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postazioni", x => x.IdPostazione);
                });

            migrationBuilder.CreateTable(
                name: "DistintaComponenti",
                columns: table => new
                {
                    CodiceComponente = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CodiceArticolo = table.Column<string>(nullable: true),
                    Descrizione = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Quantita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistintaComponenti", x => x.CodiceComponente);
                    table.ForeignKey(
                        name: "FK_DistintaComponenti_Articoli_CodiceArticolo",
                        column: x => x.CodiceArticolo,
                        principalTable: "Articoli",
                        principalColumn: "CodiceArticolo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odls",
                columns: table => new
                {
                    CodiceOdl = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    QuantitaDaProdurre = table.Column<int>(nullable: false),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    DataFine = table.Column<DateTime>(nullable: false),
                    CodiceArticolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odls", x => x.CodiceOdl);
                    table.ForeignKey(
                        name: "FK_Odls_Articoli_CodiceArticolo",
                        column: x => x.CodiceArticolo,
                        principalTable: "Articoli",
                        principalColumn: "CodiceArticolo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MacchinaFisica",
                columns: table => new
                {
                    CodiceMacchinaFisica = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CodiceCentroDiLavoro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacchinaFisica", x => x.CodiceMacchinaFisica);
                    table.ForeignKey(
                        name: "FK_MacchinaFisica_CentriDiLavoro_CodiceCentroDiLavoro",
                        column: x => x.CodiceCentroDiLavoro,
                        principalTable: "CentriDiLavoro",
                        principalColumn: "CodiceCentroDiLavoro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    IdPrenotazione = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    IdAspNetUsers = table.Column<string>(maxLength: 450, nullable: true),
                    IdPostazione = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.IdPrenotazione);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_AspNetUsers_IdAspNetUsers",
                        column: x => x.IdAspNetUsers,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Postazioni_IdPostazione",
                        column: x => x.IdPostazione,
                        principalTable: "Postazioni",
                        principalColumn: "IdPostazione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerarchiaDistintaComponente",
                columns: table => new
                {
                    CodiceComponentePadre = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CodiceComponente = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    DescrizioneComponentePadre = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerarchiaDistintaComponente", x => x.CodiceComponentePadre);
                    table.ForeignKey(
                        name: "FK_GerarchiaDistintaComponente_DistintaComponenti_CodiceComponente",
                        column: x => x.CodiceComponente,
                        principalTable: "DistintaComponenti",
                        principalColumn: "CodiceComponente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdlFasi",
                columns: table => new
                {
                    IdFaseOdl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceOdl = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CodiceArticolo = table.Column<string>(nullable: true),
                    FaseOdl = table.Column<int>(nullable: false),
                    CodiceCentroDiLavoro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdlFasi", x => x.IdFaseOdl);
                    table.ForeignKey(
                        name: "FK_OdlFasi_Articoli_CodiceArticolo",
                        column: x => x.CodiceArticolo,
                        principalTable: "Articoli",
                        principalColumn: "CodiceArticolo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFasi_CentriDiLavoro_CodiceCentroDiLavoro",
                        column: x => x.CodiceCentroDiLavoro,
                        principalTable: "CentriDiLavoro",
                        principalColumn: "CodiceCentroDiLavoro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFasi_Odls_CodiceOdl",
                        column: x => x.CodiceOdl,
                        principalTable: "Odls",
                        principalColumn: "CodiceOdl",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdlFaseVersamenti",
                columns: table => new
                {
                    IdVersamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceArticolo = table.Column<string>(nullable: true),
                    CodiceOdl = table.Column<string>(nullable: true),
                    IdFaseODL = table.Column<int>(nullable: false),
                    CodiceMacchinaFisica = table.Column<string>(nullable: true),
                    IdAspNetUsers = table.Column<string>(nullable: true),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    DataFine = table.Column<DateTime>(nullable: false),
                    TempoLavoroNetto = table.Column<DateTime>(nullable: false),
                    PezziBuoni = table.Column<int>(nullable: false),
                    PezziScartati = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdlFaseVersamenti", x => x.IdVersamento);
                    table.ForeignKey(
                        name: "FK_OdlFaseVersamenti_Articoli_CodiceArticolo",
                        column: x => x.CodiceArticolo,
                        principalTable: "Articoli",
                        principalColumn: "CodiceArticolo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFaseVersamenti_MacchinaFisica_CodiceMacchinaFisica",
                        column: x => x.CodiceMacchinaFisica,
                        principalTable: "MacchinaFisica",
                        principalColumn: "CodiceMacchinaFisica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFaseVersamenti_Odls_CodiceOdl",
                        column: x => x.CodiceOdl,
                        principalTable: "Odls",
                        principalColumn: "CodiceOdl",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFaseVersamenti_AspNetUsers_IdAspNetUsers",
                        column: x => x.IdAspNetUsers,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdlFaseVersamenti_OdlFasi_IdFaseODL",
                        column: x => x.IdFaseODL,
                        principalTable: "OdlFasi",
                        principalColumn: "IdFaseOdl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1", "ea55df16-f9c0-46ab-b2d0-4fe0bb04e8dd", "User", "User" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "fe02e2e2-3b59-4006-ba8c-04b817446e4d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "8770baa4-54ab-4534-bfa5-c932af4b2564", "admin@admin.com", true, null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEM+k7gtBKbSA0WSaY1v5UdGT9pChCcqgQ3O3SNpS72q5JDbkp/3n5YfAJgbVKgkcPg==", null, false, "", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Postazioni",
                columns: new[] { "IdPostazione", "Descrizione", "NomePostazione" },
                values: new object[,]
                {
                    { 3, "Blocco in alto: posto in alto a destra", "Posto3" },
                    { 26, "Sala Digital Manufacturing: posto a destra", "Posto26" },
                    { 25, "Sala Digital Manufacturing: posto in basso ", "Posto25" },
                    { 24, "Sala Digital Manufacturing: posto a sinistra", "Posto24" },
                    { 23, "Sala MOVE: posto in basso a sinistra", "Posto23" },
                    { 22, "Sala MOVE: posto in basso a destra", "Posto22" },
                    { 21, "Sala MOVE: posto a capotavola sinistra", "Posto21" },
                    { 20, "Sala MOVE: posto in alto a sinistra", "Posto20" },
                    { 19, "Sala MOVE: posto in alto a destra", "Posto19" },
                    { 18, "Blocco in basso: posto in alto a destra", "Posto18" },
                    { 17, "Blocco in basso: posto in basso a destra", "Posto17" },
                    { 16, "Blocco in basso: posto in basso al centro", "Posto16" },
                    { 15, "Blocco in basso: posto in basso a sinistra", "Posto15" },
                    { 1, "Blocco in alto: posto in alto a sinistra", "Posto1" },
                    { 13, "Blocco in basso: posto in alto al centro", "Posto13" },
                    { 12, "Blocco centrale: posto in basso a destra", "Posto12" },
                    { 11, "Blocco centrale: posto in basso al centro", "Posto11" },
                    { 10, "Blocco centrale: posto in basso a sinistra", "Posto10" },
                    { 9, "Blocco centrale: posto in alto a sinistra", "Posto9" },
                    { 8, "Blocco centrale: posto in alto al centro", "Posto8" },
                    { 7, "Blocco centrale: posto in alto a destra", "Posto7" },
                    { 6, "Blocco in alto: posto in basso a sinistra", "Posto6" },
                    { 5, "Blocco in alto: posto in basso al centro", "Posto5" },
                    { 4, "Blocco in alto: posto in basso a destra", "Posto4" },
                    { 2, "Blocco in alto: posto in alto al centro", "Posto2" },
                    { 14, "Blocco in basso: posto in alto a sinistra", "Posto14" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DistintaComponenti_CodiceArticolo",
                table: "DistintaComponenti",
                column: "CodiceArticolo");

            migrationBuilder.CreateIndex(
                name: "IX_GerarchiaDistintaComponente_CodiceComponente",
                table: "GerarchiaDistintaComponente",
                column: "CodiceComponente");

            migrationBuilder.CreateIndex(
                name: "IX_MacchinaFisica_CodiceCentroDiLavoro",
                table: "MacchinaFisica",
                column: "CodiceCentroDiLavoro");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFaseVersamenti_CodiceArticolo",
                table: "OdlFaseVersamenti",
                column: "CodiceArticolo");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFaseVersamenti_CodiceMacchinaFisica",
                table: "OdlFaseVersamenti",
                column: "CodiceMacchinaFisica");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFaseVersamenti_CodiceOdl",
                table: "OdlFaseVersamenti",
                column: "CodiceOdl");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFaseVersamenti_IdAspNetUsers",
                table: "OdlFaseVersamenti",
                column: "IdAspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFaseVersamenti_IdFaseODL",
                table: "OdlFaseVersamenti",
                column: "IdFaseODL");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFasi_CodiceArticolo",
                table: "OdlFasi",
                column: "CodiceArticolo");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFasi_CodiceCentroDiLavoro",
                table: "OdlFasi",
                column: "CodiceCentroDiLavoro");

            migrationBuilder.CreateIndex(
                name: "IX_OdlFasi_CodiceOdl",
                table: "OdlFasi",
                column: "CodiceOdl");

            migrationBuilder.CreateIndex(
                name: "IX_Odls_CodiceArticolo",
                table: "Odls",
                column: "CodiceArticolo");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IdAspNetUsers",
                table: "Prenotazioni",
                column: "IdAspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IdPostazione",
                table: "Prenotazioni",
                column: "IdPostazione");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GerarchiaDistintaComponente");

            migrationBuilder.DropTable(
                name: "OdlFaseVersamenti");

            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DistintaComponenti");

            migrationBuilder.DropTable(
                name: "MacchinaFisica");

            migrationBuilder.DropTable(
                name: "OdlFasi");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Postazioni");

            migrationBuilder.DropTable(
                name: "CentriDiLavoro");

            migrationBuilder.DropTable(
                name: "Odls");

            migrationBuilder.DropTable(
                name: "Articoli");
        }
    }
}
