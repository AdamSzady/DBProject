CREATE TABLE [dbo].[OrderParts](
	[OrderId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Orders] ([Id]),
	[PriceId] [int] NULL FOREIGN KEY REFERENCES [dbo].[Prices] ([Id]),
	[Number] [int] NULL DEFAULT 1
)