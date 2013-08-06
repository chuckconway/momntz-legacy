GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (2, N'Image.Small.Width', N'240', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (3, N'Image.Small.Height', N'180', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (4, N'Image.Medium.Width', N'1024', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (5, N'Image.Medium.Height', N'768', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (6, N'Image.Large.Width', N'1920', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (7, N'Image.Large.Height', N'1080', NULL)
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (10, N'cloudurl', N'http://127.0.0.1:10000/devstoreaccount1', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (11, N'cloudaccount', N'devstoreaccount1', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (12, N'cloudkey', N'Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1004, N'cloudurl', N'http://momntz.blob.core.windows.net', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1005, N'cloudaccount', N'momntz', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1006, N'cloudkey', N'k9migT9gDlx2lzwLw+nXvq7AzFYdoPwhjUyQeHA/hDz37skLB4flSS79sD3MC7EGqwWBjfCKwtgPVyrOn692Jw==', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1012, N'cloudurl', N'http://qamemorablemoments.blob.core.windows.net', N'QA')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1013, N'cloudaccount', N'qamemorablemoments', N'QA')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1014, N'cloudkey', N'9E1t/udGpskjgHd2Vhy76RoovFenWVORv3noM/Svr2bdC1UkB/iGcdBup46jbwGdk+fLcoa1URtLnkivMDXyEw==', N'QA')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1015, N'ServiceBus.Queue', N'Endpoint=sb://momntzdev.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=TU9SBGWvdxeO6THM8uQrxA9fmJEhTlLHha80rTkNj7Y=', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1016, N'ServiceBus.Queue', N'Endpoint=sb://momntzqa.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=IbgyP8beHL15QtPGUN3KKFsogMUozdeX7603EF7xd40=', N'QA')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1017, N'ServiceBus.Queue', N'Endpoint=sb://momntz.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=6d1C5tpI4JRCUqWZ1QxIx+4+M1uYZZgZiR2lYL2ieXw=', N'PROD')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1018, N'LogToFile', N'c:\logs\service.log', N'LOCAL')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1019, N'LogToFile', N'c:\logs\service.log', N'QA')
GO
INSERT [dbo].[Configuration] ([Id], [Name], [Value], [Environment]) VALUES (1020, N'LogToFile', N'c:\logs\service.log', N'PROD')
GO