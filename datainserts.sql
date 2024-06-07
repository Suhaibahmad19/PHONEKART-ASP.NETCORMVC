USE phonekartSUBMIT10MAY
   GO
   SET IDENTITY_INSERT [dbo].[Brand] ON 
   GO
   INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (1, N'Apple')
   GO
   INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (2, N'Samsung')
   GO
   INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (3, N'OnePlus')
   GO
   INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (4, N'Google')
   GO
   INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (5, N'Xiaomi')
   GO
   SET IDENTITY_INSERT [dbo].[Brand] OFF
   GO

   select *from [dbo].[Brand]
   select * from [dbo].Phone
   select*from [dbo].[OrderStatus]



   INSERT INTO Phone(Model, Price, BrandId)
   VALUES 
   ('Ipad Pro',1200.99, 1),
   ('15 PRO MAX', 1450.99, 1),
   ('15 PRO',1350.99, 1),
   ('14 PRO ', 1200.99, 1),
   ('14 PRO  MAX',1100.99, 1),
   ('TAB9 ULTRA',1200.99, 2),
   ('S24 ULTRA', 1450.99, 2),
   ('S24 PLUS',1350.99, 2),
   ('S23 ULTRA', 1150.99, 2),
   ('S23 PLUS',1000.99, 2),
   ('ONEPLUS 12',1300.99, 3),
   ('ONEPLUS 12 PRO', 1480.99, 3),
   ('ONEPLUS 11 ACE' ,1250.99, 3),
   ('ONEPLUS 10 PRO', 1150.99, 3),
   ('ONEPLUS 10',1100.99, 3),
   ('PIXEL 8 PRO',900.99, 4),
   ('PIXEL 8 ', 850.99, 4),
   ('Mi Note 12' ,1050.99, 3),
   ('Mi 12 pro', 1000.99, 3);
   

   SET IDENTITY_INSERT [dbo].[OrderStatus] ON 
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (1, 1, N'Pending')
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (2, 2, N'Shipped')
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (3, 3, N'Delivered')
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (4, 4, N'Cancelled')
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (5, 5, N'Returned')
   GO
   INSERT [dbo].[OrderStatus] ([Id], [StatusId], [StatusName]) VALUES (6, 6, N'Refund')
   GO
   SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
   GO


select* from Stock
   INSERT INTO Stock(PhoneId,Quantity)
   VALUES 
   (2,10),
   (3,10),
   (4,10),
   (5,10),
   (7,10),
   (8,10),
   (9,10),
   (10,10),
   (11,10),
   (12,10),
   (13,10),
   (14,10),
   (15,10),
   (16,10),
   (17,10),
   (18,10),
   (19,10);

