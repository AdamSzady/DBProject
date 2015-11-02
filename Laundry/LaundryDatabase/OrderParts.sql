CREATE TABLE [dbo].[OrderParts]
(
	[OrderId] INT NOT NULL FOREIGN KEY REFERENCES Orders(Id), 
    [PriceId] INT NULL, 
    [Number] INT NULL DEFAULT 1,
)
