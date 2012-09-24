SET IDENTITY_INSERT [dbo].[Configuration] ON 

GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (2, N'Image.Small.Width', N'240', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (3, N'Image.Small.Height', N'180', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (4, N'Image.Medium.Width', N'1024', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (5, N'Image.Medium.Height', N'768', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (6, N'Image.Large.Width', N'1920', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (7, N'Image.Large.Height', N'1080', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (9, N'Database.Queue', N'Data Source=localhost;Initial Catalog=NewMomntz.Queue;User Id=momntz;Password=folsom_1;', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (10, N'cloudurl', N'http://127.0.0.1:10000/devstoreaccount1', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (11, N'cloudaccount', N'devstoreaccount1', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (12, N'cloudkey', N'Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (13, N'cloudurl', N'http://qamemorablemoments.blob.core.windows.net', N'PREVIEW')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (14, N'cloudaccount', N'qamemorablemoments', N'PREVIEW')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (15, N'cloudkey', N'9E1t/udGpskjgHd2Vhy76RoovFenWVORv3noM/Svr2bdC1UkB/iGcdBup46jbwGdk+fLcoa1URtLnkivMDXyEw==', N'PREVIEW')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (16, N'cloudurl', N'http://127.0.0.1:10000/devstoreaccount1', N'TEST')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (17, N'cloudaccount', N'devstoreaccount1', N'TEST')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (18, N'cloudkey', N'Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==', N'TEST')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (19, N'Database.Queue', N'Data Source=localhost;Initial Catalog=NewMomntz.Queue;User Id=momntz;Password=folsom_1;', N'TEST')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (20, N'Database.Queue', N'Data Source=192.168.1.109;Initial Catalog=PreviewMomntz.Queue;User Id=momntz;Password=folsom_1;', N'PREVIEW')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (1003, N'Database.Queue', N'Server=tcp:gha9fb98fk.database.windows.net,1433;Database=Momntz.Queue;User ID=cconway;Password=Austin_1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (1004, N'cloudurl', N'http://momntz.blob.core.windows.net', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (1005, N'cloudaccount', N'momntz', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Key], [Value], [Environment]) VALUES (1006, N'cloudkey', N'k9migT9gDlx2lzwLw+nXvq7AzFYdoPwhjUyQeHA/hDz37skLB4flSS79sD3MC7EGqwWBjfCKwtgPVyrOn692Jw==', N'PROD')
GO
SET IDENTITY_INSERT [dbo].[Configuration] OFF
GO
