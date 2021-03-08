USE [CarCenter]
GO
/****** Object:  Table [dbo].[Carros]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Carros](
	[CarroId] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](150) NOT NULL,
	[Modelo] [int] NULL,
	[Placa] [varchar](10) NOT NULL,
	[Observaciones] [varchar](max) NULL,
	[ClienteId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[TipoCliente] [varchar](50) NOT NULL,
	[PersonaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DetalleFacturas]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetalleFacturas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DetalleFacturas](
	[DetalleFacturaId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NULL,
	[TotalDetalle] [numeric](18, 2) NULL,
	[FacturaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facturas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Facturas](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaFactura] [datetime] NULL,
	[Subtotal] [numeric](18, 2) NULL,
	[ValorIva] [numeric](18, 2) NULL,
	[Total] [numeric](18, 2) NULL,
	[ClienteId] [int] NULL,
	[SedeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Mecanicos]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mecanicos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Mecanicos](
	[MecanicoId] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [bit] NOT NULL,
	[PersonaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MecanicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Personas](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[TipoDocumento] [varchar](2) NOT NULL,
	[NumeroDocumento] [varchar](15) NOT NULL,
	[Celular] [varchar](20) NOT NULL,
	[CorreoElectronico] [varchar](150) NOT NULL,
 CONSTRAINT [PK__Personas__7C34D30360FA0C2F] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Productos](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[ValorUnitario] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Sedes]    Script Date: 7/03/2021 10:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sedes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sedes](
	[SedeId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[SedeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ClienteId], [TipoCliente], [PersonaId]) VALUES (1, N'Natural', 2)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleFacturas] ON 
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (1, 1, 1, CAST(300000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (2, 2, 1, CAST(80000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (3, 3, 1, CAST(500000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (4, 4, 4, CAST(1280000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (5, 6, 1, CAST(180000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (6, 7, 1, CAST(600000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[DetalleFacturas] ([DetalleFacturaId], [ProductoId], [Cantidad], [TotalDetalle], [FacturaId]) VALUES (8, 5, 2, CAST(1600000.00 AS Numeric(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[DetalleFacturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 
GO
INSERT [dbo].[Facturas] ([FacturaId], [FechaFactura], [Subtotal], [ValorIva], [Total], [ClienteId], [SedeId]) VALUES (1, CAST(N'2021-03-07T00:00:00.000' AS DateTime), CAST(4540000.00 AS Numeric(18, 2)), CAST(862600.00 AS Numeric(18, 2)), CAST(5402600.00 AS Numeric(18, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Mecanicos] ON 
GO
INSERT [dbo].[Mecanicos] ([MecanicoId], [Estado], [PersonaId]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Mecanicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 
GO
INSERT [dbo].[Personas] ([PersonaId], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [TipoDocumento], [NumeroDocumento], [Celular], [CorreoElectronico]) VALUES (1, N'Jorge', N'Luis', N'Fonseca', N'Rivera', N'CC', N'111111', N'123456789', N'jfonseca@domain.com')
GO
INSERT [dbo].[Personas] ([PersonaId], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [TipoDocumento], [NumeroDocumento], [Celular], [CorreoElectronico]) VALUES (2, N'Pepito', NULL, N'Perez', NULL, N'CC', N'222222', N'987654321', N'pperez@domain.com')
GO
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (1, N'Exosto', CAST(300000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (2, N'Tapa Gasolina', CAST(80000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (3, N'Frenos', CAST(500000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (4, N'LLantas x 1', CAST(320000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (5, N'Puertas x 1', CAST(800000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (6, N'Espejos x 2', CAST(180000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [ValorUnitario]) VALUES (7, N'Radio', CAST(600000.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Sedes] ON 
GO
INSERT [dbo].[Sedes] ([SedeId], [Nombre]) VALUES (1, N'Norte')
GO
INSERT [dbo].[Sedes] ([SedeId], [Nombre]) VALUES (2, N'Sur')
GO
INSERT [dbo].[Sedes] ([SedeId], [Nombre]) VALUES (3, N'Oriente')
GO
INSERT [dbo].[Sedes] ([SedeId], [Nombre]) VALUES (4, N'Occidente')
GO
SET IDENTITY_INSERT [dbo].[Sedes] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Carros__ClienteI__2E1BDC42]') AND parent_object_id = OBJECT_ID(N'[dbo].[Carros]'))
ALTER TABLE [dbo].[Carros]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Clientes__Person__2B3F6F97]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK__Clientes__Person__2B3F6F97] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Personas] ([PersonaId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Clientes__Person__2B3F6F97]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK__Clientes__Person__2B3F6F97]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__DetalleFa__Factu__36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleFacturas]'))
ALTER TABLE [dbo].[DetalleFacturas]  WITH CHECK ADD FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Facturas] ([FacturaId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__DetalleFa__Produ__35BCFE0A]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleFacturas]'))
ALTER TABLE [dbo].[DetalleFacturas]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Facturas__Client__32E0915F]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Facturas__SedeId__37A5467C]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD FOREIGN KEY([SedeId])
REFERENCES [dbo].[Sedes] ([SedeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Mecanicos__Perso__286302EC]') AND parent_object_id = OBJECT_ID(N'[dbo].[Mecanicos]'))
ALTER TABLE [dbo].[Mecanicos]  WITH CHECK ADD  CONSTRAINT [FK__Mecanicos__Perso__286302EC] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Personas] ([PersonaId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Mecanicos__Perso__286302EC]') AND parent_object_id = OBJECT_ID(N'[dbo].[Mecanicos]'))
ALTER TABLE [dbo].[Mecanicos] CHECK CONSTRAINT [FK__Mecanicos__Perso__286302EC]
GO
