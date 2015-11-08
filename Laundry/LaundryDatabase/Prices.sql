CREATE TABLE [dbo].[Prices](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ThingId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Things] ([Id]),
	[ServiceId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Services] ([Id]),
	[Price] [float] NULL,
)
