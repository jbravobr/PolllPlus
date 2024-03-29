USE [PollPlusDataBase]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 7/17/2015 2:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[DataValidade] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Texto] [nvarchar](max) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.BlackList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoriaBanner]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaBanner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[BannerId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.CategoriaBanner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documento]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [bigint] NOT NULL,
	[Tipo] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[QtdePush] [int] NOT NULL,
	[SubDominio] [nvarchar](max) NULL,
	[Css] [nvarchar](max) NULL,
	[DocumentoId] [int] NOT NULL,
	[PlataformaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
	[AppKeyForPush] [varchar](max) NULL,
	[AppPassForPush] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmpresaBanner]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaBanner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[BannerId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.EmpresaBanner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enquete]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enquete](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
	[TipoImagem] [int] NOT NULL,
	[Imagem] [nvarchar](max) NULL,
	[ClientId] [int] NOT NULL,
	[UrlVideo] [nvarchar](max) NULL,
	[TemVoucher] [bit] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[EmpresaId] [int] NULL,
	[PerguntaId] [int] NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
	[QtdePush] [int] NOT NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.Enquete] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnqueteCategoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnqueteCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnqueteId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.EnqueteCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnqueteVoucher]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnqueteVoucher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnqueteId] [int] NOT NULL,
	[VoucherId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.EnqueteVoucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Filial]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Filial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Geolocalizacao]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Geolocalizacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Geolocalizacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log4Net]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log4Net](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mensagem]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensagem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Texto] [nvarchar](max) NULL,
	[AlcanceEmKm] [int] NOT NULL,
	[EhRascunho] [bit] NOT NULL,
	[Tipo] [int] NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Mensagem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MensagemCategoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MensagemCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MensagemId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.MensagemCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pergunta]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pergunta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextoPergunta] [nvarchar](max) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Pergunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PerguntaResposta]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerguntaResposta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerguntaId] [int] NOT NULL,
	[RespostaId] [int] NOT NULL,
	[Respondida] [bit] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
	[percentual] [float] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.PerguntaResposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Plataforma]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plataforma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Descricao] [nvarchar](max) NULL,
	[App] [uniqueidentifier] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Plataforma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resposta]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resposta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextoResposta] [nvarchar](max) NULL,
	[PerguntaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Resposta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subcategoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeSubCategoria] [nvarchar](max) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Subcategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubcategoriaCategoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubcategoriaCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubcategoriaId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.SubcategoriaCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsoPushPorEmpresa]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsoPushPorEmpresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[QtdePushDisponiveis] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.UsoPushPorEmpresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Senha] [nvarchar](max) NULL,
	[Sexo] [int] NOT NULL,
	[DDD] [int] NOT NULL,
	[Telefone] [nvarchar](max) NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Municipio] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Perfil] [int] NOT NULL,
	[EmpresaId] [int] NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
	[FacebookID] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioCategoria]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCategoria](
	[Id] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.UsuarioCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[UsuarioId] ASC,
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioPlataforma]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPlataforma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[PlataformaId] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.UsuarioPlataforma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/17/2015 2:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificador] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[DataValidade] [datetime] NOT NULL,
	[Usado] [bit] NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[UsuarioId] [int] NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (1, N'banner_2.jpg', N'http://google.com.br', CAST(N'2015-07-31 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-14 09:10:03.290' AS DateTime), NULL)
GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (2, N'_body-tech-1332021201.png', N'www.bodytech.com.br', CAST(N'2015-07-16 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-15 00:26:56.147' AS DateTime), NULL)
GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (3, N'_body-tech-1332021201.png', N'www.bodytech.com.br', CAST(N'2015-07-16 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-15 00:27:04.570' AS DateTime), NULL)
GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (4, N'banner_2.jpg', N'google.com.br', CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-16 01:48:13.830' AS DateTime), NULL)
GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (5, N'banner_3.jpg', N'google.com.br', CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-16 01:51:17.717' AS DateTime), NULL)
GO
INSERT [dbo].[Banner] ([Id], [FileName], [Url], [DataValidade], [Status], [DataCriacao], [DataAtualizacao]) VALUES (6, N'banner_7.jpeg', N'google.com.br', CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, CAST(N'2015-07-16 01:52:22.920' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (1, N'Tecnologia', 0, CAST(N'2015-07-06 00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (2, N'Esporte', 0, CAST(N'2015-07-06 15:06:58.287' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (3, N'Gastronomia', 0, CAST(N'2015-07-06 15:07:10.523' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (4, N'Entretenimento', 0, CAST(N'2015-07-06 15:07:21.193' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (6, N'Lazer', 0, CAST(N'2015-07-06 15:08:03.320' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (8, N'Games', 0, CAST(N'2015-07-07 16:26:30.163' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (9, N'Vinhos', 0, CAST(N'2015-07-11 16:36:33.563' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (10, N'Moda', 0, CAST(N'2015-07-11 16:40:33.733' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (12, N'Ninja', 0, CAST(N'2015-07-14 09:08:04.713' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (13, N'Política', 0, CAST(N'2015-07-14 18:42:26.480' AS DateTime), NULL)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Status], [DataCriacao], [DataAtualizacao]) VALUES (14, N'Educação', 0, CAST(N'2015-07-14 18:42:36.887' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriaBanner] ON 

GO
INSERT [dbo].[CategoriaBanner] ([Id], [CategoriaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (1, 1, 1, CAST(N'2015-07-14 09:10:03.447' AS DateTime), NULL)
GO
INSERT [dbo].[CategoriaBanner] ([Id], [CategoriaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (2, 2, 3, CAST(N'2015-07-15 00:27:04.697' AS DateTime), NULL)
GO
INSERT [dbo].[CategoriaBanner] ([Id], [CategoriaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (3, 1, 5, CAST(N'2015-07-16 01:51:37.680' AS DateTime), NULL)
GO
INSERT [dbo].[CategoriaBanner] ([Id], [CategoriaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (4, 2, 6, CAST(N'2015-07-16 01:52:23.957' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[CategoriaBanner] OFF
GO
SET IDENTITY_INSERT [dbo].[Documento] ON 

GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (1, 1943829000190, 0, CAST(N'2015-07-06 00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (2, 8205820001693, 0, CAST(N'2015-07-07 16:22:55.053' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (3, 7036303000103, 0, CAST(N'2015-07-12 02:03:18.327' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (4, 7036303000103, 0, CAST(N'2015-07-12 11:43:48.480' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (5, 32578117000143, 0, CAST(N'2015-07-12 13:45:02.483' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (6, 1943829000190, 0, CAST(N'2015-07-14 09:07:46.213' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (7, 45897000150, 0, CAST(N'2015-07-14 18:38:27.967' AS DateTime), NULL)
GO
INSERT [dbo].[Documento] ([Id], [Numero], [Tipo], [DataCriacao], [DataAtualizacao]) VALUES (8, 56585157000180, 0, CAST(N'2015-07-16 02:19:53.070' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Documento] OFF
GO
SET IDENTITY_INSERT [dbo].[Empresa] ON 

GO
INSERT [dbo].[Empresa] ([Id], [Nome], [Logo], [QtdePush], [SubDominio], [Css], [DocumentoId], [PlataformaId], [DataCriacao], [DataAtualizacao], [AppKeyForPush], [AppPassForPush]) VALUES (2, N'Empresa Teste', N'teste.png', 10, N'empresateste', N'#233540', 1, 1, CAST(N'2015-07-06 00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Empresa] ([Id], [Nome], [Logo], [QtdePush], [SubDominio], [Css], [DocumentoId], [PlataformaId], [DataCriacao], [DataAtualizacao], [AppKeyForPush], [AppPassForPush]) VALUES (3, N'Empresa Teste', NULL, 10, N'empresateste', N'#233541', 6, 6, CAST(N'2015-07-14 09:07:46.213' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Empresa] ([Id], [Nome], [Logo], [QtdePush], [SubDominio], [Css], [DocumentoId], [PlataformaId], [DataCriacao], [DataAtualizacao], [AppKeyForPush], [AppPassForPush]) VALUES (4, N'Empresa teste XPTO', NULL, 20, N'maisxpto.com.br', N'1700EF', 7, 7, CAST(N'2015-07-14 18:38:27.967' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Empresa] ([Id], [Nome], [Logo], [QtdePush], [SubDominio], [Css], [DocumentoId], [PlataformaId], [DataCriacao], [DataAtualizacao], [AppKeyForPush], [AppPassForPush]) VALUES (5, N'Empresa Demo', NULL, 100, N'demo', N'48004F', 8, 8, CAST(N'2015-07-16 02:19:53.070' AS DateTime), NULL, N'AAAA', N'123')
GO
SET IDENTITY_INSERT [dbo].[Empresa] OFF
GO
SET IDENTITY_INSERT [dbo].[EmpresaBanner] ON 

GO
INSERT [dbo].[EmpresaBanner] ([Id], [EmpresaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (1, 2, 1, CAST(N'2015-07-14 09:10:03.337' AS DateTime), NULL)
GO
INSERT [dbo].[EmpresaBanner] ([Id], [EmpresaId], [BannerId], [DataCriacao], [DataAtualizacao]) VALUES (2, 2, 3, CAST(N'2015-07-15 00:27:04.570' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[EmpresaBanner] OFF
GO
SET IDENTITY_INSERT [dbo].[Enquete] ON 

GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (5, N'Pergunta mobilidade', 1, 2, 0, NULL, 0, NULL, 0, 1, NULL, 5, CAST(N'2015-07-14 03:58:43.687' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (6, N'Mobilidade II', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 6, CAST(N'2015-07-14 04:01:50.250' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (7, N'Mobilidade 3', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 7, CAST(N'2015-07-14 04:08:54.610' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (8, N'Mobilidade 4', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 8, CAST(N'2015-07-14 04:13:07.347' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (9, N'Hotmail ', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 9, CAST(N'2015-07-14 08:37:24.087' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (10, NULL, 2, 1, 0, NULL, 0, N'https://www.youtube.com/embed/l_0CN-12npY', 0, 1, 2, 10, CAST(N'2015-07-14 08:40:10.383' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (11, NULL, 2, 1, 0, N'banner_5.jpg', 0, NULL, 0, 1, 2, 11, CAST(N'2015-07-14 08:49:06.933' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (12, NULL, 2, 1, 0, N'banner_1.jpeg', 0, NULL, 0, 1, 2, 12, CAST(N'2015-07-14 08:53:18.010' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (13, N'Primeira notícia criada - com vídeo URL', 1, 3, 0, NULL, 0, N'https://www.youtube.com/embed/l_0CN-12npY', 0, 1, 2, NULL, CAST(N'2015-07-14 08:56:09.230' AS DateTime), NULL, 0, N'Descrição da Notícia')
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (14, N'bbb', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 13, CAST(N'2015-07-14 10:34:44.950' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (15, N'teste naty', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 14, CAST(N'2015-07-14 18:33:43.433' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (16, N'Enquete feita no iOS 8.4 - iPhone 6', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 15, CAST(N'2015-07-14 21:26:07.737' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (17, NULL, 2, 1, 0, NULL, 0, N'https://www.youtube.com/watch?v=jsgPy-K8ogk', 0, 1, 2, 16, CAST(N'2015-07-15 00:47:11.257' AS DateTime), NULL, 0, NULL)
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (18, N'Noticia do Rodrigo', 2, 3, 0, NULL, 0, N'https://www.youtube.com/watch?v=jsgPy-K8ogk', 0, 1, 2, NULL, CAST(N'2015-07-15 00:48:48.947' AS DateTime), NULL, 0, N'Aqui é a descrição')
GO
INSERT [dbo].[Enquete] ([Id], [Titulo], [Status], [Tipo], [TipoImagem], [Imagem], [ClientId], [UrlVideo], [TemVoucher], [UsuarioId], [EmpresaId], [PerguntaId], [DataCriacao], [DataAtualizacao], [QtdePush], [Descricao]) VALUES (19, N'Qual sua série preferida?', 2, 2, 0, NULL, 0, NULL, 0, 1, NULL, 17, CAST(N'2015-07-15 20:08:26.827' AS DateTime), NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Enquete] OFF
GO
SET IDENTITY_INSERT [dbo].[EnqueteCategoria] ON 

GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (1, 10, 1, CAST(N'2015-07-14 08:40:10.477' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (2, 11, 3, CAST(N'2015-07-14 08:49:07.260' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (3, 12, 3, CAST(N'2015-07-14 08:53:18.057' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (4, 13, 9, CAST(N'2015-07-14 08:56:09.230' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (5, 17, 1, CAST(N'2015-07-15 00:47:11.337' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteCategoria] ([Id], [EnqueteId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (6, 18, 1, CAST(N'2015-07-15 00:48:48.947' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[EnqueteCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[EnqueteVoucher] ON 

GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (1, 12, 1, CAST(N'2015-07-14 18:59:16.077' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (2, 12, 2, CAST(N'2015-07-14 18:59:16.277' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (3, 12, 3, CAST(N'2015-07-14 18:59:16.293' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (4, 12, 4, CAST(N'2015-07-14 18:59:16.293' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (5, 12, 5, CAST(N'2015-07-14 18:59:16.310' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (6, 12, 6, CAST(N'2015-07-14 18:59:16.327' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (7, 12, 7, CAST(N'2015-07-14 18:59:16.340' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (8, 12, 8, CAST(N'2015-07-14 18:59:16.357' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (9, 12, 9, CAST(N'2015-07-14 18:59:16.357' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (10, 12, 10, CAST(N'2015-07-14 18:59:16.373' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (11, 19, 11, CAST(N'2015-07-16 01:41:37.540' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (12, 19, 12, CAST(N'2015-07-16 01:41:43.420' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (13, 19, 13, CAST(N'2015-07-16 01:41:45.530' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (14, 19, 14, CAST(N'2015-07-16 01:41:47.760' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (15, 19, 15, CAST(N'2015-07-16 01:41:50.050' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (16, 19, 16, CAST(N'2015-07-16 01:41:52.157' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (17, 19, 17, CAST(N'2015-07-16 01:41:54.443' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (18, 19, 18, CAST(N'2015-07-16 01:41:56.643' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (19, 19, 19, CAST(N'2015-07-16 01:41:58.747' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (20, 19, 20, CAST(N'2015-07-16 01:42:00.873' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (21, 19, 21, CAST(N'2015-07-16 02:11:54.477' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (22, 19, 22, CAST(N'2015-07-16 02:11:54.663' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (23, 19, 23, CAST(N'2015-07-16 02:11:54.680' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (24, 19, 24, CAST(N'2015-07-16 02:11:54.697' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (25, 17, 25, CAST(N'2015-07-16 02:14:18.493' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (26, 17, 26, CAST(N'2015-07-16 02:14:18.507' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (27, 17, 27, CAST(N'2015-07-16 02:14:18.523' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (28, 17, 28, CAST(N'2015-07-16 02:14:18.540' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (29, 17, 29, CAST(N'2015-07-16 02:14:18.557' AS DateTime), NULL)
GO
INSERT [dbo].[EnqueteVoucher] ([Id], [EnqueteId], [VoucherId], [DataCriacao], [DataAtualizacao]) VALUES (30, 17, 30, CAST(N'2015-07-16 02:14:18.557' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[EnqueteVoucher] OFF
GO
SET IDENTITY_INSERT [dbo].[Geolocalizacao] ON 

GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (1, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:14:30.283' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (2, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:14:41.640' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (3, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:14:52.657' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (4, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:03.797' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (5, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:14.673' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (6, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:25.703' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (7, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:36.843' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (8, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:47.797' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (9, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:15:58.687' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (10, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:16:09.813' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (11, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:16:20.627' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (12, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:16:31.157' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (13, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:16:41.767' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (14, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:16:52.640' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (15, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:17:03.187' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (16, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:18:40.017' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (17, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:18:50.580' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (18, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 20:19:01.580' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (19, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:17:31.017' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (20, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:17:42.517' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (21, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:17:53.143' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (22, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:04.143' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (23, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:15.097' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (24, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:25.660' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (25, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:36.660' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (26, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:47.613' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (27, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:18:58.173' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (28, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:19:09.190' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (29, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:19:20.173' AS DateTime), NULL)
GO
INSERT [dbo].[Geolocalizacao] ([Id], [Latitude], [Longitude], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (30, 37.797698333333329, -122.40200000000002, 1, CAST(N'2015-07-13 21:19:31.160' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Geolocalizacao] OFF
GO
SET IDENTITY_INSERT [dbo].[Log4Net] ON 

GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (5, CAST(N'2015-07-14 18:54:37.183' AS DateTime), N'49', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<NovaMensagem>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Beg')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (12, CAST(N'2015-07-15 00:14:28.773' AS DateTime), N'13', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<NovaMensagem>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Beg')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (30, CAST(N'2015-07-16 02:48:42.430' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'Value cannot be null.
Parameter name: source', N'System.ArgumentNullException: Value cannot be null.
Parameter name: source
   at System.Linq.Enumerable.Select[TSource,TResult](IEnumerable`1 source, Func`2 selector)
   at PollPlus.Controllers.AccountController.<EditarUsuario>d__13.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (8, CAST(N'2015-07-15 00:05:26.100' AS DateTime), N'13', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.EnqueteController.<NovaEnquete>d__11.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Begi')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (9, CAST(N'2015-07-15 00:10:29.023' AS DateTime), N'12', N'ERROR', N'PollPlus.Controllers.BaseController', N'Object reference not set to an instance of an object.', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at ASP._Page_Views_Home_Index_cshtml.Execute() in e:\Inetroot\app01.training.cloudfacil.net\Views\Home\Index.cshtml:line 12
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (10, CAST(N'2015-07-15 00:10:29.663' AS DateTime), N'8', N'ERROR', N'PollPlus.Controllers.BaseController', N'Object reference not set to an instance of an object.', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at ASP._Page_Views_Home_Index_cshtml.Execute() in e:\Inetroot\app01.training.cloudfacil.net\Views\Home\Index.cshtml:line 12
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (15, CAST(N'2015-07-15 19:36:48.230' AS DateTime), N'16', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.EnqueteController.<NovaEnquete>d__11.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Begi')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (23, CAST(N'2015-07-16 02:45:20.273' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (24, CAST(N'2015-07-16 02:45:20.367' AS DateTime), N'17', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (6, CAST(N'2015-07-14 19:33:08.280' AS DateTime), N'7', N'ERROR', N'PollPlus.Controllers.BaseController', N'The asynchronous action method ''Login'' returns a Task, which cannot be executed synchronously.', N'System.InvalidOperationException: The asynchronous action method ''Login'' returns a Task, which cannot be executed synchronously.
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass15.<InvokeActionMethodWithFilters>b__12()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodFilter(IActionFilter filter, ActionExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodWithFilters(ControllerContext controllerContext, IList`1 filters, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeAction(ControllerContext controllerContext, String actionName)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (7, CAST(N'2015-07-14 19:35:13.373' AS DateTime), N'8', N'ERROR', N'PollPlus.Controllers.BaseController', N'Object reference not set to an instance of an object.', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at PollPlus.Controllers.BannerController.<NovoBanner>d__7.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (13, CAST(N'2015-07-15 00:14:44.193' AS DateTime), N'13', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
Enquete -> EnqueteViewModel
PollPlus.Domain.Enquete -> PollPlus.Models.EnqueteViewModel

Destination path:
EnqueteViewModel

Source value:
System.Data.Entity.DynamicProxies.Enquete_BD798215526C2277A0E66CA9D31178FC5F1238F6580BB5B763ED840C92796534', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
Enquete -> EnqueteViewModel
PollPlus.Domain.Enquete -> PollPlus.Models.EnqueteViewModel

Destination path:
EnqueteViewModel

Source value:
System.Data.Entity.DynamicProxies.Enquete_BD798215526C2277A0E66CA9D31178FC5F1238F6580BB5B763ED840C92796534 ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.DomainToViewModelMappingProfile.<>c.<Configure>b__2_0(Enquete d, EnqueteViewModel vm)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<EditarMensagem>d__9.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (14, CAST(N'2015-07-15 00:26:56.273' AS DateTime), N'11', N'ERROR', N'PollPlus.Controllers.BaseController', N'Object reference not set to an instance of an object.', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at PollPlus.Controllers.BannerController.<NovoBanner>d__7.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (16, CAST(N'2015-07-15 20:10:01.763' AS DateTime), N'22', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<NovaMensagem>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Beg')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (28, CAST(N'2015-07-16 02:45:22.057' AS DateTime), N'28', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (1, CAST(N'2015-07-14 09:06:55.777' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'Value cannot be null.
Parameter name: source', N'System.ArgumentNullException: Value cannot be null.
Parameter name: source
   at System.Linq.Enumerable.Select[TSource,TResult](IEnumerable`1 source, Func`2 selector)
   at PollPlus.Controllers.AccountController.<EditarUsuario>d__13.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (2, CAST(N'2015-07-14 09:07:04.260' AS DateTime), N'17', N'ERROR', N'PollPlus.Controllers.BaseController', N'Value cannot be null.
Parameter name: source', N'System.ArgumentNullException: Value cannot be null.
Parameter name: source
   at System.Linq.Enumerable.Select[TSource,TResult](IEnumerable`1 source, Func`2 selector)
   at PollPlus.Controllers.AccountController.<EditarUsuario>d__13.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (11, CAST(N'2015-07-15 00:10:48.287' AS DateTime), N'11', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<NovaMensagem>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Beg')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (25, CAST(N'2015-07-16 02:45:21.417' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (26, CAST(N'2015-07-16 02:45:21.853' AS DateTime), N'17', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (27, CAST(N'2015-07-16 02:45:21.947' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (3, CAST(N'2015-07-14 18:46:38.310' AS DateTime), N'49', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.EnqueteController.<NovaEnquete>d__11.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Begi')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (4, CAST(N'2015-07-14 18:52:29.670' AS DateTime), N'12', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.MensagemController.<NovaMensagem>d__8.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Beg')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (17, CAST(N'2015-07-16 02:21:40.617' AS DateTime), N'3', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.EnqueteController.<NovaEnquete>d__11.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Begi')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (18, CAST(N'2015-07-16 02:23:47.117' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel', N'AutoMapper.AutoMapperMappingException: 

Mapping types:
EnqueteViewModel -> Enquete
PollPlus.Models.EnqueteViewModel -> PollPlus.Domain.Enquete

Destination path:
Enquete

Source value:
PollPlus.Models.EnqueteViewModel ---> System.InvalidOperationException: Nullable object must have a value.
   at PollPlus.Mappers.ViewModelToDomainMappingProfile.<>c.<Configure>b__2_1(EnqueteViewModel vm, Enquete d)
   at AutoMapper.TypeMap.<get_BeforeMap>b__0(Object src, Object dest)
   at AutoMapper.Mappers.TypeMapObjectMapperRegistry.PropertyMapMappingStrategy.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.Mappers.TypeMapMapper.Map(ResolutionContext context, IMappingEngineRunner mapper)
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   --- End of inner exception stack trace ---
   at AutoMapper.MappingEngine.AutoMapper.IMappingEngineRunner.Map(ResolutionContext context)
   at AutoMapper.MappingEngine.Map[TDestination](Object source, Action`1 opts)
   at PollPlus.Controllers.EnqueteController.<NovaEnquete>d__11.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<Begi')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (19, CAST(N'2015-07-16 02:33:25.493' AS DateTime), N'28', N'ERROR', N'PollPlus.Controllers.BaseController', N'Value cannot be null.
Parameter name: source', N'System.ArgumentNullException: Value cannot be null.
Parameter name: source
   at System.Linq.Enumerable.Select[TSource,TResult](IEnumerable`1 source, Func`2 selector)
   at PollPlus.Controllers.AccountController.<EditarUsuario>d__13.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (20, CAST(N'2015-07-16 02:45:19.773' AS DateTime), N'28', N'ERROR', N'PollPlus.Controllers.BaseController', N'The layout page "~/Views/Shared/_Layout.cshtml" could not be found at the following path: "~/Views/Shared/_Layout.cshtml".', N'System.Web.HttpException (0x80004005): The layout page "~/Views/Shared/_Layout.cshtml" could not be found at the following path: "~/Views/Shared/_Layout.cshtml".
   at System.Web.WebPages.WebPageExecutingBase.NormalizeLayoutPagePath(String layoutPagePath)
   at System.Web.WebPages.StartPage.set_Layout(String value)
   at ASP._Page_Views__ViewStart_cshtml.Execute() in e:\Inetroot\app01.training.cloudfacil.net\Views\_ViewStart.cshtml:line 2
   at System.Web.WebPages.StartPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (21, CAST(N'2015-07-16 02:45:20.010' AS DateTime), N'24', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (22, CAST(N'2015-07-16 02:45:20.117' AS DateTime), N'28', N'ERROR', N'PollPlus.Controllers.BaseController', N'The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml', N'System.InvalidOperationException: The view ''Index'' or its master was not found or no view engine supports the searched locations. The following locations were searched:
~/Views/Erro/Index.aspx
~/Views/Erro/Index.ascx
~/Views/Shared/Index.aspx
~/Views/Shared/Index.ascx
~/Views/Erro/Index.cshtml
~/Views/Erro/Index.vbhtml
~/Views/Shared/Index.cshtml
~/Views/Shared/Index.vbhtml
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
INSERT [dbo].[Log4Net] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception]) VALUES (29, CAST(N'2015-07-16 02:48:29.993' AS DateTime), N'17', N'ERROR', N'PollPlus.Controllers.BaseController', N'Value cannot be null.
Parameter name: source', N'System.ArgumentNullException: Value cannot be null.
Parameter name: source
   at System.Linq.Enumerable.Select[TSource,TResult](IEnumerable`1 source, Func`2 selector)
   at PollPlus.Controllers.AccountController.<EditarUsuario>d__13.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Web.Mvc.Async.TaskAsyncActionDescriptor.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeAsynchronousActionMethod>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)')
GO
SET IDENTITY_INSERT [dbo].[Log4Net] OFF
GO
SET IDENTITY_INSERT [dbo].[Pergunta] ON 

GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (5, N'Pergunta mobilidade', CAST(N'2015-07-14 03:58:43.687' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (6, N'Mobilidade II', CAST(N'2015-07-14 04:01:50.250' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (7, N'Mobilidade 3', CAST(N'2015-07-14 04:08:54.610' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (8, N'Mobilidade 4', CAST(N'2015-07-14 04:13:07.347' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (9, N'Hotmail ', CAST(N'2015-07-14 08:37:24.103' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (10, N'Enquete pública - via backoffice (com vídeo)', CAST(N'2015-07-14 08:40:10.430' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (11, N'Enquete pública - via backoffice (com imagem)', CAST(N'2015-07-14 08:49:06.993' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (12, N'Outra para Gastronomia', CAST(N'2015-07-14 08:53:18.010' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (13, N'bbb', CAST(N'2015-07-14 10:34:44.967' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (14, N'teste naty', CAST(N'2015-07-14 18:33:43.433' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (15, N'Enquete feita no iOS 8.4 - iPhone 6', CAST(N'2015-07-14 21:26:07.753' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (16, N'Enquete do Rodrigo', CAST(N'2015-07-15 00:47:11.257' AS DateTime), NULL)
GO
INSERT [dbo].[Pergunta] ([Id], [TextoPergunta], [DataCriacao], [DataAtualizacao]) VALUES (17, N'Qual sua série preferida?', CAST(N'2015-07-15 20:08:26.840' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Pergunta] OFF
GO
SET IDENTITY_INSERT [dbo].[PerguntaResposta] ON 

GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (2, 8, 30, 0, 1, CAST(N'2015-07-14 04:13:55.987' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (3, 9, 33, 0, 1, CAST(N'2015-07-14 08:37:46.040' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (5, 12, 45, 0, 1, CAST(N'2015-07-14 08:55:21.040' AS DateTime), NULL, 33)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (6, 10, 35, 0, 1, CAST(N'2015-07-14 09:01:53.527' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (7, 11, 40, 0, 1, CAST(N'2015-07-14 09:03:55.823' AS DateTime), NULL, 33)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (8, 12, 43, 0, 1, CAST(N'2015-07-14 09:04:34.247' AS DateTime), NULL, 66)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (10, 10, 35, 0, 1, CAST(N'2015-07-14 10:32:19.420' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (11, 10, 35, 0, 1, CAST(N'2015-07-14 11:44:37.063' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (12, 11, 39, 0, 1, CAST(N'2015-07-14 18:32:52.480' AS DateTime), NULL, 66)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (13, 10, 35, 0, 1, CAST(N'2015-07-14 21:25:27.533' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (14, 11, 39, 0, 1, CAST(N'2015-07-15 19:29:44.183' AS DateTime), NULL, 66)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (15, 12, 43, 0, 1, CAST(N'2015-07-15 19:30:53.260' AS DateTime), NULL, 66)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (16, 10, 35, 0, 1, CAST(N'2015-07-15 23:20:38.910' AS DateTime), NULL, 100)
GO
INSERT [dbo].[PerguntaResposta] ([Id], [PerguntaId], [RespostaId], [Respondida], [UsuarioId], [DataCriacao], [DataAtualizacao], [percentual]) VALUES (17, 10, 35, 0, 1, CAST(N'2015-07-15 23:20:39.783' AS DateTime), NULL, 100)
GO
SET IDENTITY_INSERT [dbo].[PerguntaResposta] OFF
GO
SET IDENTITY_INSERT [dbo].[Plataforma] ON 

GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (1, N'Android Application', N'Versão para Androi', N'4cf5232f-3f6f-4cd9-ae26-e7e4f1df5175', CAST(N'2015-07-06 00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (2, NULL, NULL, N'8abae8b3-a4ed-40b7-998d-8d04da012d0d', CAST(N'2015-07-07 16:22:55.053' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (3, NULL, NULL, N'655b6964-dc91-49c2-ae97-c673084187d7', CAST(N'2015-07-12 02:03:18.327' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (4, NULL, NULL, N'57970c40-f94f-48a8-8141-2c84de0b51ff', CAST(N'2015-07-12 11:43:48.480' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (5, NULL, NULL, N'71001d8b-63d0-4749-980e-0e07e457d8e5', CAST(N'2015-07-12 13:45:02.483' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (6, NULL, NULL, N'4cf5232f-3f6f-4cd9-ae26-e7e4f1df5175', CAST(N'2015-07-14 09:07:46.213' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (7, NULL, NULL, N'19b58c41-e826-417c-bffd-d4f44368e064', CAST(N'2015-07-14 18:38:27.967' AS DateTime), NULL)
GO
INSERT [dbo].[Plataforma] ([Id], [Nome], [Descricao], [App], [DataCriacao], [DataAtualizacao]) VALUES (8, NULL, NULL, N'7c9dd556-e8ef-40e8-9764-771afbeab402', CAST(N'2015-07-16 02:19:53.070' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Plataforma] OFF
GO
SET IDENTITY_INSERT [dbo].[Resposta] ON 

GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (18, N'A1', 5, CAST(N'2015-07-14 03:58:46.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (19, N'B2', 5, CAST(N'2015-07-14 03:58:46.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (20, N'C3', 5, CAST(N'2015-07-14 03:58:46.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (21, N'D', 5, CAST(N'2015-07-14 03:58:46.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (22, N'X', 6, CAST(N'2015-07-14 04:01:50.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (23, N'Y', 6, CAST(N'2015-07-14 04:01:50.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (24, N'Z', 6, CAST(N'2015-07-14 04:01:50.783' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (25, N'1', 7, CAST(N'2015-07-14 04:08:55.143' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (26, N'2', 7, CAST(N'2015-07-14 04:08:55.143' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (27, N'3', 7, CAST(N'2015-07-14 04:08:55.143' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (28, N'A', 8, CAST(N'2015-07-14 04:13:07.877' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (29, N'B', 8, CAST(N'2015-07-14 04:13:07.877' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (30, N'C', 8, CAST(N'2015-07-14 04:13:07.877' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (31, N'D', 8, CAST(N'2015-07-14 04:13:07.877' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (32, N'Sim', 9, CAST(N'2015-07-14 08:37:24.727' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (33, N'Nao', 9, CAST(N'2015-07-14 08:37:24.727' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (34, N'Tanto faz', 9, CAST(N'2015-07-14 08:37:24.727' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (35, N'A', 10, CAST(N'2015-07-14 08:40:10.633' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (36, N'B', 10, CAST(N'2015-07-14 08:40:10.650' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (37, N'C', 10, CAST(N'2015-07-14 08:40:10.667' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (38, N'D', 10, CAST(N'2015-07-14 08:40:10.667' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (39, N'V', 11, CAST(N'2015-07-14 08:49:07.417' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (40, N'B', 11, CAST(N'2015-07-14 08:49:07.557' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (41, N'N', 11, CAST(N'2015-07-14 08:49:07.573' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (42, N'Ovo', 12, CAST(N'2015-07-14 08:53:18.057' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (43, N'Peixe', 12, CAST(N'2015-07-14 08:53:18.073' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (44, N'Agrião', 12, CAST(N'2015-07-14 08:53:18.073' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (45, N'Pato', 12, CAST(N'2015-07-14 08:53:18.073' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (46, N'a', 13, CAST(N'2015-07-14 10:34:45.467' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (47, N'v', 13, CAST(N'2015-07-14 10:34:45.467' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (48, N'a', 14, CAST(N'2015-07-14 18:33:44.683' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (49, N'b', 14, CAST(N'2015-07-14 18:33:44.683' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (50, N'c', 14, CAST(N'2015-07-14 18:33:44.683' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (51, N'd', 14, CAST(N'2015-07-14 18:33:44.683' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (52, N'Primeira', 15, CAST(N'2015-07-14 21:26:08.190' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (53, N'Segunda', 15, CAST(N'2015-07-14 21:26:08.190' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (54, N'Terceira', 15, CAST(N'2015-07-14 21:26:08.190' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (55, N'Quarta', 15, CAST(N'2015-07-14 21:26:08.190' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (56, N'B', 16, CAST(N'2015-07-15 00:47:11.367' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (57, N'C', 16, CAST(N'2015-07-15 00:47:11.507' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (58, N'D', 16, CAST(N'2015-07-15 00:47:11.507' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (59, N'E', 16, CAST(N'2015-07-15 00:47:11.507' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (60, N'Game of Thrones', 17, CAST(N'2015-07-15 20:08:27.403' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (61, N'Scandal', 17, CAST(N'2015-07-15 20:08:27.403' AS DateTime), NULL)
GO
INSERT [dbo].[Resposta] ([Id], [TextoResposta], [PerguntaId], [DataCriacao], [DataAtualizacao]) VALUES (62, N'Dexter', 17, CAST(N'2015-07-15 20:08:27.403' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Resposta] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (1, N'Rodrigo Amaro dos Santos Amaral', N'jbravo.br@gmail.com', N'123456789', 0, 21, N'975519377', CAST(N'1983-07-21 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, 2, CAST(N'2015-07-13 20:09:50.923' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (3, N'Nathalia Barreiros', N'naty_10rj@yahoo.com.br', N'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA3oOurAqKuEmDVrEwE1qnNAQAAAACAAAAAAAQZgAAAAEAACAAAAA8EjP+EV8lvt64GNjPeWF4bTE0PZ1CtxAMJNMmpnb2hgAAAAAOgAAAAAIAACAAAADVhspgPy5Jde9IgGu84rw2lvslzUa+2WGEh7QE+ap/XxAAAADBI0ZoANd/sPywVo12k1GjQAAAAKMraV1E2ctHl7l9BGgVq7PLOhLxqbJm0q4vEPgqv8AqbhNvXb1YXRB83RGgBQJPYxt9A1ajdPzjkF26KD6DhGs=', 0, 21, N'996863038', CAST(N'1982-10-06 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-13 23:43:35.400' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (16, N'Nathalia', N'nathalia.contato@gmail.com', NULL, 1, 21, N'99999-9999', CAST(N'1983-07-07 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 09:07:23.277' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (17, N'Andre', N'andre.contato@gmail.com', NULL, 0, 21, N'99999-9999', CAST(N'1983-07-07 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 09:07:23.277' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (18, N'Sam', N'sam.contato@gmail.com', NULL, 0, 21, N'99999-9999', CAST(N'1983-07-07 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 09:07:23.277' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (19, N'Sarah', N'sarah.contato@gmail.com', NULL, 1, 21, N'99999-9999', CAST(N'1983-07-07 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 09:07:23.277' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (20, N'Amaral', N'jbravo_br@hotmail.com', N'123', 0, 21, N'975519377', CAST(N'1983-07-21 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 09:15:45.573' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (21, N'Nathalia Barreiros', N'nathaliabarreiros.contato@gmail.com', N'123456', 0, 21, N'996873038', CAST(N'1982-10-06 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-14 20:13:47.140' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (22, N'pedro', N'pedrocezaz@gmail.com', N'123456789', 0, 21, N'34078930', CAST(N'1960-06-29 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 1, 4, CAST(N'2015-07-14 23:54:42.320' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (23, N'Magaly', N'magalybcamara@hotmail.com', N'123456', 0, 21, N'996873038', CAST(N'1958-12-02 00:00:00.000' AS DateTime), N'Niterói', 0, 0, NULL, CAST(N'2015-07-15 18:17:33.523' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (24, N'Nathalia 3', N'naty10rj@hotmail.com', N'123456', 0, 21, N'996873038', CAST(N'1983-10-06 00:00:00.000' AS DateTime), N'Rio de Janeiro', 0, 0, NULL, CAST(N'2015-07-15 19:21:08.340' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (25, N'Patrícia Russ ', N'pmeirelesruss@gmail.com ', N'123', 0, 21, N'91267350', CAST(N'1986-04-04 00:00:00.000' AS DateTime), N'Rio de Janeiro ', 0, 0, NULL, CAST(N'2015-07-15 23:06:58.377' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Sexo], [DDD], [Telefone], [DataNascimento], [Municipio], [Status], [Perfil], [EmpresaId], [DataCriacao], [DataAtualizacao], [FacebookID]) VALUES (26, N'Usuario Demo', N'd_emidio@yahoo.com.br', N'123456', 1, 21, N'999999999', CAST(N'1986-12-03 00:00:00.000' AS DateTime), N'Niteroi', 0, 0, 2, CAST(N'2015-07-16 02:18:28.210' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[UsuarioCategoria] ([Id], [UsuarioId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (0, 1, 1, CAST(N'2015-07-13 20:09:51.657' AS DateTime), NULL)
GO
INSERT [dbo].[UsuarioCategoria] ([Id], [UsuarioId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (0, 1, 2, CAST(N'2015-07-13 20:09:51.657' AS DateTime), NULL)
GO
INSERT [dbo].[UsuarioCategoria] ([Id], [UsuarioId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (0, 1, 8, CAST(N'2015-07-13 20:09:51.657' AS DateTime), NULL)
GO
INSERT [dbo].[UsuarioCategoria] ([Id], [UsuarioId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (0, 22, 3, CAST(N'2015-07-14 23:54:43.037' AS DateTime), NULL)
GO
INSERT [dbo].[UsuarioCategoria] ([Id], [UsuarioId], [CategoriaId], [DataCriacao], [DataAtualizacao]) VALUES (0, 26, 4, CAST(N'2015-07-16 02:18:28.290' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Voucher] ON 

GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (1, N'0e718bc9-5ec8-b2a4-6de9-d41e0a314513', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 1, NULL, NULL, CAST(N'2015-07-14 18:59:15.903' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (2, N'e54b7c73-0b07-e222-e617-26252aeaf4bd', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 1, NULL, NULL, CAST(N'2015-07-14 18:59:16.263' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (3, N'abd9c709-390c-3cbf-fa6f-ca9e05631d12', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.277' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (4, N'a7707eae-939b-e5c4-fcaa-c4d935a74e9d', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.293' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (5, N'fd45fd70-c068-1f48-625d-e37fe6e5d0bc', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.310' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (6, N'ef75dd70-21cb-48af-491b-bcb1d4e61d99', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.327' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (7, N'72f09e32-3db2-1334-4e1b-79910293774e', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.327' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (8, N'62a71391-0e77-d9c6-dc46-bd3fce0e89af', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.340' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (9, N'9a9d5388-9626-1073-12dd-9e4ab24595a1', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.357' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (10, N'7cd64853-58ff-ae73-19ea-65f7370824b7', 0, CAST(N'2016-02-01 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-14 18:59:16.373' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (11, N'd7185046-89cb-cd25-da41-aeb562ccd8b5', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:32.357' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (12, N'9eca7a91-3191-8cf7-c56f-b15f849cf27a', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:42.370' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (13, N'ea5922b3-19d8-8971-3385-fb0573f927fd', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:44.473' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (14, N'f145c3d7-ab9e-d54a-2466-fc8d67f76b99', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:46.660' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (15, N'ecb2b47c-78e3-ff61-69de-c396de1d5686', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:49.007' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (16, N'df968d9f-8bd3-ed1e-7cd4-6b312a0c4e79', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:51.110' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (17, N'edc423d3-98c0-c86a-7009-1b3cabddb87c', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:53.197' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (18, N'f1c90fe8-57bd-fb79-6e86-9a7a2d213efd', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:55.577' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (19, N'3fe4c5c9-52ee-3da9-161f-6dfc30af257f', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:57.687' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (20, N'4a9a3fd5-46d6-affd-e8a2-8a3595c0ad20', 0, CAST(N'1983-07-31 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 01:41:59.810' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (21, N'f75c289d-2b3c-a5b2-b740-11daee27290f', 0, CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:11:53.727' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (22, N'b1154c07-2f70-4969-42d7-008cea73e28d', 0, CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:11:54.647' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (23, N'dde5192d-d080-0fe8-263f-ac7273e4d07b', 0, CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:11:54.680' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (24, N'1df757b2-9e1c-b9d1-d049-4ffc506d1770', 0, CAST(N'2015-01-07 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:11:54.697' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (25, N'f4bf2fb1-8975-1b62-68fb-3e0a506fc130', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.493' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (26, N'2c2a5469-85e2-8977-3735-aa095a87f340', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.507' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (27, N'80b20107-b6b2-827d-bd55-139c7646ee0e', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.507' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (28, N'30e904cf-2c7b-bcb0-7d73-b80a89e0cec5', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.523' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (29, N'e9423191-4655-9fc5-ace6-66071dbd3d13', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.540' AS DateTime), NULL)
GO
INSERT [dbo].[Voucher] ([Id], [Identificador], [Status], [DataValidade], [Usado], [Descricao], [UsuarioId], [DataCriacao], [DataAtualizacao]) VALUES (30, N'72381cba-ddab-3a52-1b4f-c6151435268b', 0, CAST(N'2015-07-23 00:00:00.000' AS DateTime), 0, NULL, NULL, CAST(N'2015-07-16 02:14:18.557' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO
ALTER TABLE [dbo].[CategoriaBanner]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.CategoriaBanner_dbo.Banner_BannerId] FOREIGN KEY([BannerId])
REFERENCES [dbo].[Banner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriaBanner] CHECK CONSTRAINT [FK_dbo.CategoriaBanner_dbo.Banner_BannerId]
GO
ALTER TABLE [dbo].[CategoriaBanner]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.CategoriaBanner_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoriaBanner] CHECK CONSTRAINT [FK_dbo.CategoriaBanner_dbo.Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[Empresa]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Empresa_dbo.Documento_DocumentoId] FOREIGN KEY([DocumentoId])
REFERENCES [dbo].[Documento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_dbo.Empresa_dbo.Documento_DocumentoId]
GO
ALTER TABLE [dbo].[Empresa]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Empresa_dbo.Plataforma_PlataformaId] FOREIGN KEY([PlataformaId])
REFERENCES [dbo].[Plataforma] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_dbo.Empresa_dbo.Plataforma_PlataformaId]
GO
ALTER TABLE [dbo].[EmpresaBanner]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EmpresaBanner_dbo.Banner_BannerId] FOREIGN KEY([BannerId])
REFERENCES [dbo].[Banner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpresaBanner] CHECK CONSTRAINT [FK_dbo.EmpresaBanner_dbo.Banner_BannerId]
GO
ALTER TABLE [dbo].[EmpresaBanner]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EmpresaBanner_dbo.Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpresaBanner] CHECK CONSTRAINT [FK_dbo.EmpresaBanner_dbo.Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[Enquete]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Enquete_dbo.Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Enquete] CHECK CONSTRAINT [FK_dbo.Enquete_dbo.Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[Enquete]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Enquete_dbo.Pergunta_PerguntaId] FOREIGN KEY([PerguntaId])
REFERENCES [dbo].[Pergunta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enquete] CHECK CONSTRAINT [FK_dbo.Enquete_dbo.Pergunta_PerguntaId]
GO
ALTER TABLE [dbo].[Enquete]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Enquete_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enquete] CHECK CONSTRAINT [FK_dbo.Enquete_dbo.Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[EnqueteCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EnqueteCategoria_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnqueteCategoria] CHECK CONSTRAINT [FK_dbo.EnqueteCategoria_dbo.Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[EnqueteCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EnqueteCategoria_dbo.Enquete_EnqueteId] FOREIGN KEY([EnqueteId])
REFERENCES [dbo].[Enquete] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnqueteCategoria] CHECK CONSTRAINT [FK_dbo.EnqueteCategoria_dbo.Enquete_EnqueteId]
GO
ALTER TABLE [dbo].[EnqueteVoucher]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EnqueteVoucher_dbo.Enquete_EnqueteId] FOREIGN KEY([EnqueteId])
REFERENCES [dbo].[Enquete] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnqueteVoucher] CHECK CONSTRAINT [FK_dbo.EnqueteVoucher_dbo.Enquete_EnqueteId]
GO
ALTER TABLE [dbo].[EnqueteVoucher]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.EnqueteVoucher_dbo.Voucher_VoucherId] FOREIGN KEY([VoucherId])
REFERENCES [dbo].[Voucher] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnqueteVoucher] CHECK CONSTRAINT [FK_dbo.EnqueteVoucher_dbo.Voucher_VoucherId]
GO
ALTER TABLE [dbo].[Geolocalizacao]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Geolocalizacao_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Geolocalizacao] CHECK CONSTRAINT [FK_dbo.Geolocalizacao_dbo.Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Mensagem]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Mensagem_dbo.Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mensagem] CHECK CONSTRAINT [FK_dbo.Mensagem_dbo.Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[MensagemCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.MensagemCategoria_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MensagemCategoria] CHECK CONSTRAINT [FK_dbo.MensagemCategoria_dbo.Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[MensagemCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.MensagemCategoria_dbo.Mensagem_MensagemId] FOREIGN KEY([MensagemId])
REFERENCES [dbo].[Mensagem] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MensagemCategoria] CHECK CONSTRAINT [FK_dbo.MensagemCategoria_dbo.Mensagem_MensagemId]
GO
ALTER TABLE [dbo].[PerguntaResposta]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Pergunta_PerguntaId] FOREIGN KEY([PerguntaId])
REFERENCES [dbo].[Pergunta] ([Id])
GO
ALTER TABLE [dbo].[PerguntaResposta] CHECK CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Pergunta_PerguntaId]
GO
ALTER TABLE [dbo].[PerguntaResposta]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Resposta_RespostaId] FOREIGN KEY([RespostaId])
REFERENCES [dbo].[Resposta] ([Id])
GO
ALTER TABLE [dbo].[PerguntaResposta] CHECK CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Resposta_RespostaId]
GO
ALTER TABLE [dbo].[PerguntaResposta]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[PerguntaResposta] CHECK CONSTRAINT [FK_dbo.PerguntaResposta_dbo.Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Resposta]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Resposta_dbo.Pergunta_PerguntaId] FOREIGN KEY([PerguntaId])
REFERENCES [dbo].[Pergunta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_dbo.Resposta_dbo.Pergunta_PerguntaId]
GO
ALTER TABLE [dbo].[SubcategoriaCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.SubcategoriaCategoria_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubcategoriaCategoria] CHECK CONSTRAINT [FK_dbo.SubcategoriaCategoria_dbo.Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[SubcategoriaCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.SubcategoriaCategoria_dbo.Subcategoria_SubcategoriaId] FOREIGN KEY([SubcategoriaId])
REFERENCES [dbo].[Subcategoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubcategoriaCategoria] CHECK CONSTRAINT [FK_dbo.SubcategoriaCategoria_dbo.Subcategoria_SubcategoriaId]
GO
ALTER TABLE [dbo].[UsoPushPorEmpresa]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.UsoPushPorEmpresa_dbo.Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsoPushPorEmpresa] CHECK CONSTRAINT [FK_dbo.UsoPushPorEmpresa_dbo.Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[Usuario]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Usuario_dbo.Empresa_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_dbo.Usuario_dbo.Empresa_EmpresaId]
GO
ALTER TABLE [dbo].[UsuarioCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.UsuarioCategoria_dbo.Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioCategoria] CHECK CONSTRAINT [FK_dbo.UsuarioCategoria_dbo.Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[UsuarioCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.UsuarioCategoria_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioCategoria] CHECK CONSTRAINT [FK_dbo.UsuarioCategoria_dbo.Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[UsuarioPlataforma]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.UsuarioPlataforma_dbo.Plataforma_PlataformaId] FOREIGN KEY([PlataformaId])
REFERENCES [dbo].[Plataforma] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPlataforma] CHECK CONSTRAINT [FK_dbo.UsuarioPlataforma_dbo.Plataforma_PlataformaId]
GO
ALTER TABLE [dbo].[UsuarioPlataforma]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.UsuarioPlataforma_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPlataforma] CHECK CONSTRAINT [FK_dbo.UsuarioPlataforma_dbo.Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Voucher]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Voucher_dbo.Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Voucher] CHECK CONSTRAINT [FK_dbo.Voucher_dbo.Usuario_UsuarioId]
GO
