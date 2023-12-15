using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdCardClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdCardClient);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccount",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    Reservations = table.Column<double>(type: "float", nullable: false),
                    Valuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCardClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAccount", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_CurrentAccount_Clients_IdCardClient",
                        column: x => x.IdCardClient,
                        principalTable: "Clients",
                        principalColumn: "IdCardClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccount_IdCardClient",
                table: "CurrentAccount",
                column: "IdCardClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentAccount");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
