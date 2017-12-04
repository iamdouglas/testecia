CREATE TABLE [dbo].[Enterprise]
(
	[IdEnterprise] INT NOT NULL PRIMARY KEY, 
    [StreetAddress] VARCHAR(200) NULL, 
    [City] VARCHAR(50) NULL, 
    [State] CHAR(2) NULL, 
    [ZipCode] VARCHAR(50) NULL, 
    [CorporateActivity] VARCHAR(50) NULL
)
