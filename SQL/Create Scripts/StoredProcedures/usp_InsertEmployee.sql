IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertEmployee]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_InsertEmployee]
GO

CREATE PROCEDURE [dbo].[usp_InsertEmployee]
(
	@OrganizationId int,
	@LastName nvarchar(128),
	@Name nvarchar(128),
	@MiddleName nvarchar(128),
	@DateOfBirth datetime,
	@PassportSeries nvarchar(4),
	@PassportNumber nvarchar(6),
	@Comment nvarchar(256)
)
AS
BEGIN
	INSERT INTO Employee(OrganizationId, LastName, [Name], MiddleName, DateOfBirth, PassportSeries, PassportNumber, Comment)
		VALUES(@OrganizationId, @LastName, @Name, @MiddleName, @DateOfBirth, @PassportSeries, @PassportNumber, @Comment)
END
GO
