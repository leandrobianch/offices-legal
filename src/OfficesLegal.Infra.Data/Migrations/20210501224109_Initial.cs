using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficesLegal.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PROCESS_CASE",
                columns: table => new
                {
                    ID_PROCESS_CASE = table.Column<int>(type: "int", nullable: false, comment: "Primary key table")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "that represents the case number according to the National Council of Justice\r\n                            (CNJ) standard.It has the format: NNNNNNN - NN.NNNN.N.NN.NNNN, where N can be any positive\r\n                            integer"),
                    COURT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "that represents the name of the court of origin of the case. Example: Supreme\r\n                          Federal Court.\r\n                         "),
                    NAME_OF_THE_RESPONSIBLE = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "representing the name of the lawyer responsible for the case."),
                    REGISTRATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date on which the case was registered in the system.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROCESS_CASE", x => x.ID_PROCESS_CASE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PROCESS_CASE");
        }
    }
}
