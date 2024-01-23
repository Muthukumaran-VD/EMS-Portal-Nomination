using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Portal_Nomination.Migrations
{
    public partial class AddUsersNomination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserNomination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsWorked = table.Column<int>(type: "int", nullable: false),
                    TechnologiesWorked = table.Column<int>(type: "int", nullable: false),
                    OutsideParticipation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeOfMonthAwardReceived = table.Column<bool>(type: "bit", nullable: false),
                    MonthsAwardReceived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherProjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestWorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardNomination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNomination", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNomination");
        }
    }
}
