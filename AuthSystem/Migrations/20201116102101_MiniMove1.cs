using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthSystem.Migrations
{
    public partial class MiniMove1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GerarchiaDistintaComponente",
                columns: table => new
                {
                    CodiceComponente = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CodiceComponentePadre = table.Column<string>(type: "nvarchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerarchiaDistintaComponente", x => x.CodiceComponente);
                    table.ForeignKey(
                        name: "FK_GerarchiaDistintaComponente_DistintaComponenti_CodiceComponente",
                        column: x => x.CodiceComponente,
                        principalTable: "DistintaComponenti",
                        principalColumn: "CodiceComponente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                column: "ConcurrencyStamp",
                value: "ff69de14-4a83-4cc8-a587-2c114a459e8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "2c3a615c-e43d-45cd-be12-1a580e31b063");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "573ce2fd-b05a-4e24-893f-4a59687fda07", "AQAAAAEAACcQAAAAEJdYOlOESkQaDYhcD2K2m874LcgWtymDgBnTZslQ0QDwjDkaZgAWJzgrvJODo8o0OQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GerarchiaDistintaComponente");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                column: "ConcurrencyStamp",
                value: "182f2724-b055-4e4b-b81b-a8c360d151d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "7d0df071-5218-47a3-9869-94b813b92cd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "263c72f7-1a7e-470f-a273-a7892dfd8221", "AQAAAAEAACcQAAAAEAw8lsaj2WSx7p/9gUpSHS0wxnuHLfx55UU16jA9ADfT/Xr0WYDW+p/Nn17A/6j/Dg==" });
        }
    }
}
