﻿CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[ClientId] [nvarchar](128) NOT NULL,
	[WorkerId] [nvarchar](128) NOT NULL,
	[GivingAddress] [nvarchar](256) NULL,
	[GivingDate] [datetime] NULL,
	[ReceiveAddress] [nvarchar](256) NULL,
	[ReceiveDate] [datetime] NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([WorkerId])
REFERENCES [dbo].[AspNetUsers] ([Id])