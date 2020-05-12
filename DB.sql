USE [Cervejaria]
GO
/****** Object:  Table [dbo].[Acesso]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acesso](
	[ID_LOGIN] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL] [varchar](100) NULL,
	[SENHA] [varchar](12) NULL,
	[ATIVO] [varchar](1) NULL,
	[PERFIL] [varchar](15) NULL,
	[NOME] [varchar](30) NULL,
	[SOBRENOME] [varchar](30) NULL,
 CONSTRAINT [PK_Acesso] PRIMARY KEY CLUSTERED 
(
	[ID_LOGIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atendimento]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atendimento](
	[AtendimentoId] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NULL,
	[IdCliente] [int] NULL,
	[IdCompra] [int] NULL,
 CONSTRAINT [PK_Atendimento] PRIMARY KEY CLUSTERED 
(
	[AtendimentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Cpf] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Total] [float] NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[EntradaId] [int] IDENTITY(1,1) NOT NULL,
	[VendaId] [int] NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Entrada] PRIMARY KEY CLUSTERED 
(
	[EntradaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[FornecedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[CNPJ] [nvarchar](50) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[FornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[FuncionarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[IdChefe] [int] NULL,
	[IdLogin] [int] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[FuncionarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[InsumoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[InsumoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCompra]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCompra](
	[ItemCompraId] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NULL,
	[Quantidade] [int] NULL,
	[Valor] [float] NULL,
	[IdFornecedor] [int] NULL,
 CONSTRAINT [PK_ItemCompra] PRIMARY KEY CLUSTERED 
(
	[ItemCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemEstoque]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemEstoque](
	[ItemEstoqueId] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NULL,
	[Quantidade] [int] NULL,
 CONSTRAINT [PK_ItemEstoque] PRIMARY KEY CLUSTERED 
(
	[ItemEstoqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemReceita]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemReceita](
	[ItemReceitaId] [int] IDENTITY(1,1) NOT NULL,
	[IdReceita] [int] NULL,
	[IdInsumo] [int] NULL,
	[Quantidade] [int] NULL,
 CONSTRAINT [PK_ItemReceita] PRIMARY KEY CLUSTERED 
(
	[ItemReceitaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](500) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receita]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita](
	[ReceitaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Descricao] [nvarchar](500) NULL,
 CONSTRAINT [PK_Receita] PRIMARY KEY CLUSTERED 
(
	[ReceitaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saida]    Script Date: 11/05/2020 20:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saida](
	[SaidaId] [int] IDENTITY(1,1) NOT NULL,
	[IdInsumo] [int] NULL,
	[Quantidade] [int] NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Saida] PRIMARY KEY CLUSTERED 
(
	[SaidaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Cliente]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Compra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([CompraId])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Compra]
GO
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Funcionario] FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[Funcionario] ([FuncionarioId])
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Funcionario]
GO
ALTER TABLE [dbo].[Entrada]  WITH CHECK ADD  CONSTRAINT [FK_Entrada_Compra] FOREIGN KEY([VendaId])
REFERENCES [dbo].[Compra] ([CompraId])
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Compra]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Acesso] FOREIGN KEY([IdLogin])
REFERENCES [dbo].[Acesso] ([ID_LOGIN])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Acesso]
GO
ALTER TABLE [dbo].[ItemCompra]  WITH CHECK ADD  CONSTRAINT [FK_ItemCompra_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([FornecedorId])
GO
ALTER TABLE [dbo].[ItemCompra] CHECK CONSTRAINT [FK_ItemCompra_Fornecedor]
GO
ALTER TABLE [dbo].[ItemCompra]  WITH CHECK ADD  CONSTRAINT [FK_ItemCompra_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([ProdutoId])
GO
ALTER TABLE [dbo].[ItemCompra] CHECK CONSTRAINT [FK_ItemCompra_Produto]
GO
ALTER TABLE [dbo].[ItemEstoque]  WITH CHECK ADD  CONSTRAINT [FK_ItemEstoque_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([ProdutoId])
GO
ALTER TABLE [dbo].[ItemEstoque] CHECK CONSTRAINT [FK_ItemEstoque_Produto]
GO
ALTER TABLE [dbo].[ItemReceita]  WITH CHECK ADD  CONSTRAINT [FK_ItemReceita_Insumo] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumo] ([InsumoId])
GO
ALTER TABLE [dbo].[ItemReceita] CHECK CONSTRAINT [FK_ItemReceita_Insumo]
GO
ALTER TABLE [dbo].[ItemReceita]  WITH CHECK ADD  CONSTRAINT [FK_ItemReceita_Receita] FOREIGN KEY([IdReceita])
REFERENCES [dbo].[Receita] ([ReceitaId])
GO
ALTER TABLE [dbo].[ItemReceita] CHECK CONSTRAINT [FK_ItemReceita_Receita]
GO


INSERT INTO Acesso (EMAIL, SENHA, ATIVO, PERFIL, NOME, SOBRENOME)
VALUES ('admin@admin.com', '123456', 'S', 'Administrador', 'Admin', 'Sistema')
  
INSERT INTO Acesso (EMAIL, SENHA, ATIVO, PERFIL, NOME, SOBRENOME)
VALUES ('user@user.com', '123456', 'S', 'Usuario', 'User', 'Sistema')