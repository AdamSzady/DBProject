CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ClientId] [nvarchar](128) NOT NULL FOREIGN KEY REFERENCES [dbo].[AspNetUsers] ([Id]),
	[WorkerId] [nvarchar](128) NULL,
	[GivingAddress] [nvarchar](256) NULL,
	[GivingDate] [datetime] NULL,
	[ReceiveAddress] [nvarchar](256) NULL,
	[ReceiveDate] [datetime] NULL,
	[Price] [float] NULL,
)