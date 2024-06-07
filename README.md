# PHONEKART (A basic e-comm system for beginners)📚🛒

📢 Initially , this project was built with .net 7. But it works fine with .net 6+ and now it is **Upgraded to .net 8.0.** I will try to keep it up to date.

## Tech stack 🧑‍💻

- Dotnet core mvc (.Net 8)
- MS SQLServer (Database)
- Entity Framework Core (ORM)
- Identity Core (Authentication)
- Bootstrap 5 (frontend)

## How to run the project?🌐

I am assuming that, you have already installed **Visual Studio 2022** (It is the latest as of march,2024) and **MS SQL Server Management Studio** (I am using mssql server 2022 as of march,2024). Now, follow the following steps.

1.Open command prompt. Go to a directory where you want to clone this project. Use this command to clone the project.

```bash
git clone https://github.com/Suhaibahmad19/PHONEKART-ASP.NETCORMVC
```

2.Go to the directory where you have cloned this project, open the directory `PHONEKART`. You will find a file with name `PHONEKART.sln`. Double click on this file and this project will be opened in Visual Studio.

3.Open `appsettings.json` file and update connection string

```json
"ConnectionStrings": {
  "conn": "data source=your_server_name;initial catalog=MovieStoreMvc; integrated security=true;encrypt=false"
}
```

4.Delete `Migrations` folder.

5.Open Tools > Package Manager > Package manager console

6.Run these 2 commands (works only with Visual studio)

```bash
  add-migration init

  update-database
```

7.Now you can run this project.

## How to register as admin and login?? 🧑‍💻🧑‍💻

1.Open the `Program.cs` file , you will find these commented lines

```c#
//using(var scope = app.Services.CreateScope())
//{
//    await DbSeeder.SeedDefaultData(scope.ServiceProvider);
//}
```

Uncomment these line and run the project. `Now stop the project and comment these lines again.`

2.Now click on login and login with these credentials.

```text
username: admin@gmail.com

password: Admin@123
```

## Data Entry 📈📉

I have provided some data of these 3 tables to test the application.

**⚠️Note: Data entry of Brand and Smartphone is optional, you can do it from admin panel but you must enter some data for OrderStatus.**

- Brand (You can also add it from the admin panel)
- Smartphone (You can also add it from the admin panel)
- OrderStatus (⚠️It Contain Constants. You Can not enter OrderStatus from the Admin panel. It must be added through sql server)

Please, run these scripts in a order. Brand data must be added before Smartphone.

### Brand

```sql
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

```

### Smartphone

```sql
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

```

### Order Status

```sql
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

```

### Stock

```sql
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
```

## Thanks

If you find this repository useful, then consider to leave a ⭐.

Connect with me

👉 LinkedIn: <https://www.linkedin.com/in/suhaibahmad42/>

Thanks a lot 🙂🙂
