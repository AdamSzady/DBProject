CREATE TABLE [dbo].[OrderParts](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[OrderId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Orders] ([Id]),
	[PriceId] [int] NULL FOREIGN KEY REFERENCES [dbo].[Prices] ([Id]),
	[Number] [int] NULL DEFAULT 1
)