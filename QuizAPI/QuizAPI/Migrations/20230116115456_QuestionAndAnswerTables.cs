using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    public partial class QuestionAndAnswerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_AspNetUsers_UserId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Quiz_QuizId",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_AuthorId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Subject_SubjectId",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mark",
                table: "Mark");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "Quizzes");

            migrationBuilder.RenameTable(
                name: "QuestionAnswer",
                newName: "QuestionAnswers");

            migrationBuilder.RenameTable(
                name: "Mark",
                newName: "Marks");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_SubjectId",
                table: "Quizzes",
                newName: "IX_Quizzes_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_AuthorId",
                table: "Quizzes",
                newName: "IX_Quizzes_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_UserId",
                table: "Marks",
                newName: "IX_Marks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_QuizId",
                table: "Marks",
                newName: "IX_Marks_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                columns: new[] { "QuestionId", "AnswerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marks",
                table: "Marks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_AnswerId",
                table: "QuestionAnswers",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_AspNetUsers_UserId",
                table: "Marks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Quizzes_QuizId",
                table: "Marks",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Answers_AnswerId",
                table: "QuestionAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Questions_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_AuthorId",
                table: "Quizzes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Subjects_SubjectId",
                table: "Quizzes",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_AspNetUsers_UserId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Quizzes_QuizId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Answers_AnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Questions_QuestionId",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_AuthorId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Subjects_SubjectId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_AnswerId",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marks",
                table: "Marks");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quiz");

            migrationBuilder.RenameTable(
                name: "QuestionAnswers",
                newName: "QuestionAnswer");

            migrationBuilder.RenameTable(
                name: "Marks",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_SubjectId",
                table: "Quiz",
                newName: "IX_Quiz_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_AuthorId",
                table: "Quiz",
                newName: "IX_Quiz_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_UserId",
                table: "Mark",
                newName: "IX_Mark_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_QuizId",
                table: "Mark",
                newName: "IX_Mark_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer",
                columns: new[] { "QuestionId", "AnswerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mark",
                table: "Mark",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_AspNetUsers_UserId",
                table: "Mark",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Quiz_QuizId",
                table: "Mark",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_AuthorId",
                table: "Quiz",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Subject_SubjectId",
                table: "Quiz",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
