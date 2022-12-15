CREATE DATABASE [WebApiDabberDB]
GO

USE [WebApiDabberDB]
GO

CREATE TABLE [WebApiDabberDB].[dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](60) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [WebApiDabberDB].[dbo].[Employees] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL,
	CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [WebApiDabberDB].[dbo].[Companies] ON 
INSERT [dbo].[Companies] ([Id], [Name], [Address], [Country]) VALUES (1, N'Web apps Inc.', N'Varna', N'BG')
INSERT [dbo].[Companies] ([Id], [Name], [Address], [Country]) VALUES (2, N'Cloud Tech', N'Sofia', N'BG')
SET IDENTITY_INSERT [dbo].[Companies] OFF

SET IDENTITY_INSERT [WebApiDabberDB].[dbo].[Employees] ON 
INSERT [dbo].[Employees] ([Id], [Name], [Age], [Position], [CompanyId]) VALUES (1, N'John Smith', 26, N'Software developer', 1)
INSERT [dbo].[Employees] ([Id], [Name], [Age], [Position], [CompanyId]) VALUES (2, N'Kanye West', 35, N'Project Manager', 2)
INSERT [dbo].[Employees] ([Id], [Name], [Age], [Position], [CompanyId]) VALUES (3, N'McLovin', 30, N'Software developer', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF

ALTER TABLE [WebApiDabberDB].[dbo].[Employees] WITH CHECK ADD CONSTRAINT [FK_Employees_Companies] FOREIGN KEY ([CompanyId])
REFERENCES [WebApiDabberDB].[dbo].[Companies] ([Id])
GO

ALTER TABLE [WebApiDabberDB].[dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Companies]
GO

CREATE PROCEDURE [dbo].[ShowCompanyByEmployeeId] @Id int
AS
	SELECT c.Id, c.Name, c.Address, c.Country
	  FROM Companies c JOIN Employees e ON c.Id = e.CompanyId
	 WHERE e.Id = @Id
GO