using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DavesPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareerRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    careerIcon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    careerJobTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    careerRoleTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    careerShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    careerLongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    careerStateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    careerEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerRecords");
        }
    }
}
