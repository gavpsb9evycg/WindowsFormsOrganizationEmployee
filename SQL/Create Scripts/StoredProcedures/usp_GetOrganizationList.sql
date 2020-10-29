IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetOrganizationList]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_GetOrganizationList]
GO

CREATE PROCEDURE [dbo].[usp_GetOrganizationList]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		Id, [Name], Inn, LegalAddress, PhysicalAddress, Comment
	FROM
		Organization WITH(NOLOCK)
END

GO
