CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientId] NVARCHAR(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id), 
    [WorkerId] NVARCHAR(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id), 
    [GivingAddress] NVARCHAR(256) NULL, 
    [GivingDate] DATETIME NULL, 
    [ReceiveAddress] NVARCHAR(256) NULL, 
    [ReceiveDate] DATETIME NULL, 
    [Price] FLOAT NULL,

)
