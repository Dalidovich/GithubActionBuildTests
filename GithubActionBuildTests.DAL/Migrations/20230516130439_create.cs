using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubActionBuildTests.DAL.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummaryCalcs",
                columns: table => new
                {
                    pk_summary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    method_name = table.Column<string>(type: "character varying", nullable: false),
                    first_num = table.Column<short>(type: "smallint", nullable: false),
                    second_num = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryCalcs", x => x.pk_summary_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryCalcs");
        }
    }
}
