using Microsoft.EntityFrameworkCore.Migrations;

namespace IvySurvey.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false),
                    optionText = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseMasters_QuestionMasters_Id",
                        column: x => x.Id,
                        principalTable: "QuestionMasters",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseMasters_optionMasters_OptionId",
                        column: x => x.OptionId,
                        principalTable: "optionMasters",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseMasters_QuestionMasters_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionMasters",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponseMasters_OptionId",
                table: "ResponseMasters",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseMasters_QuestionId",
                table: "ResponseMasters",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseMasters");
        }
    }
}
