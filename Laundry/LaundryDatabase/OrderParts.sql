CREATE TABLE [dbo].[OrderParts](
	[OrderId] [int] NOT NULL,
	[PriceId] [int] NULL,
	[Number] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderParts]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderParts] ADD  DEFAULT ((1)) FOR [Number]