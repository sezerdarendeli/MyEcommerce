USE [MyECommerce]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/22/2017 12:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddresName] [nvarchar](max) NULL,
	[NameSurName] [nvarchar](max) NULL,
	[AddressText] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[BasketId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Basket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UrlName] [nvarchar](max) NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Descprition] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[BrandName] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[CurrencyCode] [nvarchar](max) NULL,
	[UrlName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/22/2017 12:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[EMailAdress] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[ActivationCode] [nvarchar](max) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[EMailConfirmed] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201708201704141_InitialCreate', N'MyECommerce.DataLayer.DataContext.MyECommerceDataContext', 0x1F8B0800000000000400ED5BCD6EE33610BE17E83B083AB540D6CACFA50DEC5D244E52048D37E92ABB775AA21D6125CA25A9D47EB63DF491FA0A1D4A9444EAC7962CC99B0D82051616A9F9480EBF99214793FFBEFD3BFEB00E7CE31953E68564629E8C8E4D031327743DB29C98115FBCFBCDFCF0FEE79FC6D76EB036BEA4EF9D89F74092B089F9C4F9EADCB298F38403C44681E7D090850B3E72C2C0426E689D1E1FFF6E9D9C5818204CC0328CF1A788702FC0F1033C4E43E2E0158F903F0B5DEC33D90E3D768C6A7C4401662BE4E08939DB5C4FC320C0D4C1A32BC4D11DDA601AFF02148ED7DC342E7C0FC1C46CEC2F4C03111272C461DAE79F19B6390DC9D25E4103F21F372B0CEF2D90CFB05CCE79FE7AD3951D9F8A9559B9600AE5448C87414BC09333A92AAB28BE97C2CD4C95A0CC6B503ADF8855C70A9D9817AE4B3163A6511CEB7CEA53F19EAEEE58DEC36C24F68B628E4712E0C8A87AED28E30BD04AFC3B32A691CF238A2704479C22FFC87888E6BEE7FC89378FE1574C2624F27D75CA3069E8D31AA0E981862B4CF9E6135EC885DCBAA661E9725651301353649235DE127E766A1A1F617034F771C608451F360F29FE03134C11C7EE03E21C53223070ACD3D2E885B1807974F778DB31125D8BDF290E9019CCD43466687D87C9923FC176A1B569DC786BECA62D12FB33F1C0AA4188D368E750E27F3BA207194B52E831B6DC5EC71A5B39E1B79AC125625F31DFDF0A12F93723D8B5D30EF79E33425D86A18F11696D0689B2BB1A133CBA91D319E6AF08C9A5774199522C14FAE8E5E606F10C27CF5BB11A537C0A78CB906EF627798AF046F306CE7370AFF999FA0719E7015158753B33694CCA7BEA0269F6A76422FF46C88378CC3E8E30D2D109E7D6D2D1D59E1B06A2A68C0FFB735302BC91F32578CB07EA3939E342D06C7BBE5D61E6ACA897DCC4069EEF6D8096185CFCE0035D5244DC836C417A7CE8EC42220A11C9D94C61E41F34CA367642C2E576088FB1F89B036A10D70E6201D733E4F91732E132F8B18DB17F42EA0E7F7B1777BA781F0E6290FBDF9486BA8EC6BB0A26B7F06880DD7668DB1D814867220F682D4752EC58CB7696DC03305A7A0826B5AAAF2081B7312F6601F3D924C9D351D6636D474813282580B463877C7E3B2D21E45D3B30D2CB440921EDD8212F0F6C5508D961700784F4D72579D95EB5F5D926E7296F2BC979A7B971AB26393E9EA1D50AAC4C4996CB16C34E32E5D37776FB9C719060580EAB481D67B3CD4602DF0B4795422F0C0D33BDF128E382A97324883F7583D26B3594AED1723AA8CEDA6204CAB59FBE2F7E974CA8FADBC1A8063557EE0DAC3780C8122F1D6773AB9D4F2C6B3BC847B422C84D433F0A485DA0DC269D5EC75484B4AD398A9A535691D4F6E6685ADA5885D33ADACE4EA686CBD3931D65BCB155D8AC2247AC12490A079422E71A31523ABB7E09590DDA808F7582C3D0310DA6DA2EC9B6E62879A642C5C95B9B2329F95D154A696E8E95277955A8BCB53992767C51C1B48E1743E82CF6F64BE93AD806A4AE171D86D6D5AEAC959F4EAF909AA34E1B5B103A4BC46A7CCE5A5F0C69E471AB5FCA548336204C9DE03074E9CF7FF513DEB57C6B85BF493A5A07E4E2C494E61743C3EC38DF2F11D3AB407B26D64ABE54CF2593A67AF88C9B9A636849531549EB688E97274635CD64AD2D4C35CF7C6AB69A37B7303325B7A95999D2DE024DCB706A785ACF7031E83B996C724DEED75E2B311B586B8DDC7077B98A0DCA5A9B23693946154CEB6873EA48F388FAA9236D6D7941501285A58B82D237FC817AD86B4C312758DA08A5EFC0D657CA3B155FC946CFF24F853CD358E67C76576A969240C92BA601EA7AF65C9100B2378CE320B6D891FDB73FF53D586FFEC20C116F81194FBE4098A7C727A785EACE9753696931E6FACDCA2D0FFE15C5134ADDF99DA45341403C44E78A46F28CA8F384E82F015AFFAAE2ED59B5D809AFA232B1055EDBEAC3D7410AFDA3CADC6B4F8A62B5CA3EC42A55F7ED0352ACEDDB07A3E27B950B0D7C88CABED741A0DEACB7F0EDBE1356B10A6E3715DAD6C0BD8ECDEBC376BB87958A2AB38646571B0306D9FACA8CC00FBBF7FD199B5AACB5F043D49E0115B55A9DA654ACC7EA0456AAB9EA8456AEABDACB642AAAAABE93F76D591DF53A8CA75884D449F71585461DA39F5E4CD4ED505D5930D4CD04F63E640D717EAD2E08DA8DD4AE18A85C605193626B5EE393DCCE4177F310669DCCB3B702A02AF03E8B83AAF0FB2B1DAA426F5756B4ADAAA80ABDA792A32AE86ED548E5ECCFD852FF9A770CB1D75BE610E26F7B097684C1E7A0E93BB76411A6E6036B526794BE52B0AE19E6088C1B5D50EE2D90C3A1DB0182C6D5865F901F09030CE6D8BD25F7115F45FC82311CCC7D8D03636BFBF871C9953EE7F1FD4A3CB13E9600D3F4847FBA279791E7BBD9BC6F2A7C420D84B07E197D605636175168B9C9903E86A4219054DF155E612262D7230E563E80B17B6223E107DBCF0DE8758797C8D9A449BC7A90DD1BA1AB7D7CE5A12545019318B93C3C0287DD60FDFE7FD4B5C4B2D43E0000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [UserId], [AddresName], [NameSurName], [AddressText]) VALUES (1, 1, N'İş Adresim', N'Sezer Darendeli', N'İnkılap Mahallesi İlk Kurşun')
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Basket] ON 

INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (1, 0, 1, 18, 2, CAST(N'2017-08-21T00:11:53.897' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (2, 0, 1, 28, 3, CAST(N'2017-08-21T00:15:51.157' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (3, 0, 1, 27, 1, CAST(N'2017-08-21T00:20:14.150' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (4, 0, 1, 22, 1, CAST(N'2017-08-21T00:20:58.590' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (5, 0, 1, 29, 1, CAST(N'2017-08-21T00:21:36.073' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (6, 0, 6, 24, 1, CAST(N'2017-08-21T00:39:41.700' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (7, 0, 7, 22, 3, CAST(N'2017-08-21T00:59:51.590' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (8, 0, 8, 22, 1, CAST(N'2017-08-21T01:15:05.567' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (9, 0, 9, 18, 1, CAST(N'2017-08-21T01:19:28.063' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (10, 1, 10, 23, 1, CAST(N'2017-08-21T01:26:03.127' AS DateTime))
INSERT [dbo].[Basket] ([Id], [Active], [BasketId], [ProductId], [Quantity], [CreatedTime]) VALUES (11, 1, 11, 25, 1, CAST(N'2017-08-21T01:28:57.987' AS DateTime))
SET IDENTITY_INSERT [dbo].[Basket] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (2, N'Telefon', N'telefon', 0)
INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (3, N'Akıllı Telefonlar', N'akillitelefon', 2)
INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (4, N'Bilgisayar & Tablet', N'bilgisayartablet', 0)
INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (5, N'Notebook', N'notebook', 4)
INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (6, N'Tablet', N'tablet', 4)
INSERT [dbo].[Category] ([Id], [Name], [UrlName], [ParentId]) VALUES (1008, N'Telefontest', N'test', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [BasketId], [UserId], [CreatedDate], [AddressId]) VALUES (1, 10, 1, CAST(N'2017-08-21T01:26:58.160' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [BasketId], [UserId], [CreatedDate], [AddressId]) VALUES (2, 11, 1, CAST(N'2017-08-21T01:29:18.087' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (18, N' Samsung SM-A310F Galaxy A3 (2016) White', 1099, N'Akıllı Telefon (Smartphone)', N'samsung_1.jpg', N'Samsung', 3, N'TL', N'samsung-sm')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (23, N' Lenovo Ideapad 110 80UD00T2TX ', 1899, N' Lenovo Ideapad 110 80UD00T2TX i3 (W10)', N'lenovaidepad.jpg', N'Lenovo', 5, N'TL', N'lenovo-ideapad1')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (24, N'HP 15-ay102nt i5 X9Z24E (W10)', 2599, N' HP 15-ay102nt i5 X9Z24E (W10)', N'hp15-15ay.jpg', N'HP', 5, N'TL', N'hp-15-ay1')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (25, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', 2699, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', N'casper-nirvana.jpg', N'Casper', 5, N'TL', N'casper-nirvana1')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (26, N'Apple iPad Pro 128GB Wi-Fi 12,9'''' Silver', 3949, N' HP 15-ay102nt i5 X9Z24E (W10)', N'appletablet.jpg', N'Apple', 6, N'TL', N'appleipadtablet1')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (27, N' Samsung SM-A310F Galaxy A3 (2016) White', 1099, N'Akıllı Telefon (Smartphone)', N'samsung_1.jpg', N'Samsung', 3, N'TL', N'samsung-sm2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (28, N' Samsung N920C Galaxy Note 5 Black', 2999, N' Samsung N920C Galaxy Note 5 Black', N'samsungn920c.jpg', N'Samsun', 3, N'TL', N'samsung-920nc2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (29, N' Lenovo Ideapad 110 80UD00T2TX ', 1899, N' Lenovo Ideapad 110 80UD00T2TX i3 (W10)', N'lenovaidepad.jpg', N'Lenovo', 5, N'TL', N'lenovo-ideapad2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (30, N'HP 15-ay102nt i5 X9Z24E (W10)', 2599, N' HP 15-ay102nt i5 X9Z24E (W10)', N'hp15-15ay.jpg', N'HP', 5, N'TL', N'hp-15-ay2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (31, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', 2699, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', N'casper-nirvana.jpg', N'Casper', 5, N'TL', N'casper-nirvana2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (32, N'Apple iPad Pro 128GB Wi-Fi 12,9'''' Silver', 3949, N' HP 15-ay102nt i5 X9Z24E (W10)', N'appletablet.jpg', N'Apple', 6, N'TL', N'appleipadtablet2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (33, N' Samsung SM-A310F Galaxy A3 (2016) White', 1099, N'Akıllı Telefon (Smartphone)', N'samsung_1.jpg', N'Samsung', 3, N'TL', N'samsung-sm34')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (34, N' Samsung N920C Galaxy Note 5 Black', 2999, N' Samsung N920C Galaxy Note 5 Black', N'samsungn920c.jpg', N'Samsun', 3, N'TL', N'samsung-920nc3')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (35, N' Lenovo Ideapad 110 80UD00T2TX ', 1899, N' Lenovo Ideapad 110 80UD00T2TX i3 (W10)', N'lenovaidepad.jpg', N'Lenovo', 5, N'TL', N'lenovo-ideapad2')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (36, N'HP 15-ay102nt i5 X9Z24E (W10)', 2599, N' HP 15-ay102nt i5 X9Z24E (W10)', N'hp15-15ay.jpg', N'HP', 5, N'TL', N'hp-15-ay4')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (37, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', 2699, N'Casper Nirvana F600.7200-8T45T-S i5 (W10)', N'casper-nirvana.jpg', N'Casper', 5, N'TL', N'casper-nirvana5')
INSERT [dbo].[Product] ([Id], [Name], [Price], [Descprition], [ImageUrl], [BrandName], [CategoryId], [CurrencyCode], [UrlName]) VALUES (38, N'Apple iPad Pro 128GB Wi-Fi 12,9'''' Silver', 3949, N' HP 15-ay102nt i5 X9Z24E (W10)', N'appletablet.jpg', N'Apple', 6, N'TL', N'appleipadtablet5')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [EMailAdress], [Password], [ActivationCode], [CreatedTime], [Active], [EMailConfirmed]) VALUES (1, N'sezer', N'sezer.darendeli@gmail.com', N'Y/cf/3XeN4k=', NULL, CAST(N'2017-08-20T20:04:10.127' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
