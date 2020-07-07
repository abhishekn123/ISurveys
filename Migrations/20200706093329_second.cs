using Microsoft.EntityFrameworkCore.Migrations;

namespace IvySurvey.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE Sp_MYCreateSurvey @SurveyName AS nvarchar(max),@FromDate AS DATE,@ToDate AS DATE,@DepartMentId as int,
@ReturnSurveyId int OUTPUT
AS
BEGIN 
BEGIN TRY
BEGIN TRANSACTION
INSERT INTO SurveyMasters (SurveyName,FromDate,ToDate) VALUES (@SurveyName,@FromDate,@ToDate);
select @ReturnSurveyId=SCOPE_IDENTITY();
INSERT INTO SurveyMappings(DepartmentId,Id)values(@DepartMentId,SCOPE_IDENTITY())
COMMIT TRANSACTION
PRINT 'TRANSACTION COMMITED';
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'TRANSACTION HAS SOME ERRORS';
END CATCH
END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
