IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetEmployeeList]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_GetEmployeeList]
GO

CREATE PROCEDURE [dbo].[usp_GetEmployeeList]
	@OrganizationId int
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		Id, LastName, [Name], MiddleName, DateOfBirth, PassportSeries, PassportNumber, Comment
	FROM
		Employee WITH(NOLOCK)
	WHERE
		OrganizationId = @OrganizationId
END

GO
