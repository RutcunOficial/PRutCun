USE [Rutcun]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calle]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calle](
	[PkCalle] [int] IDENTITY(1,1) NOT NULL,
	[NombreCalle] [nvarchar](max) NULL,
 CONSTRAINT [PK_Calle] PRIMARY KEY CLUSTERED 
(
	[PkCalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalleTransitada]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalleTransitada](
	[FkCalle] [int] NOT NULL,
	[FkTransporte] [int] NOT NULL,
 CONSTRAINT [PK_CalleTransitada] PRIMARY KEY CLUSTERED 
(
	[FkCalle] ASC,
	[FkTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mapas]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mapas](
	[PkMapas] [int] IDENTITY(1,1) NOT NULL,
	[MapaUrl] [nvarchar](max) NULL,
	[Fktransportes] [int] NULL,
 CONSTRAINT [PK_Mapas] PRIMARY KEY CLUSTERED 
(
	[PkMapas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoInteres]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoInteres](
	[PkPunto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_PuntoInteres] PRIMARY KEY CLUSTERED 
(
	[PkPunto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoTransitado]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoTransitado](
	[FkPunto] [int] NOT NULL,
	[FkTransporte] [int] NOT NULL,
 CONSTRAINT [PK_PuntoTransitado] PRIMARY KEY CLUSTERED 
(
	[FkPunto] ASC,
	[FkTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[PkRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[PkRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTrasporte]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTrasporte](
	[PkTipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoTrasporte] PRIMARY KEY CLUSTERED 
(
	[PkTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trasporte]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trasporte](
	[PkTransporte] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[HoraInicial] [nvarchar](max) NULL,
	[HoraFinal] [nvarchar](max) NULL,
	[Dia] [nvarchar](max) NULL,
	[Estatus] [bit] NOT NULL,
	[FkTipo] [int] NULL,
 CONSTRAINT [PK_Trasporte] PRIMARY KEY CLUSTERED 
(
	[PkTransporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[PkUser] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Nickname] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[FkRol] [int] NULL,
	[RolPkRol] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[PkUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalleTransitada]  WITH CHECK ADD  CONSTRAINT [FK_CalleTransitada_Calle_FkCalle] FOREIGN KEY([FkCalle])
REFERENCES [dbo].[Calle] ([PkCalle])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalleTransitada] CHECK CONSTRAINT [FK_CalleTransitada_Calle_FkCalle]
GO
ALTER TABLE [dbo].[CalleTransitada]  WITH CHECK ADD  CONSTRAINT [FK_CalleTransitada_Trasporte_FkTransporte] FOREIGN KEY([FkTransporte])
REFERENCES [dbo].[Trasporte] ([PkTransporte])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalleTransitada] CHECK CONSTRAINT [FK_CalleTransitada_Trasporte_FkTransporte]
GO
ALTER TABLE [dbo].[Mapas]  WITH CHECK ADD  CONSTRAINT [FK_Mapas_Trasporte_Fktransportes] FOREIGN KEY([Fktransportes])
REFERENCES [dbo].[Trasporte] ([PkTransporte])
GO
ALTER TABLE [dbo].[Mapas] CHECK CONSTRAINT [FK_Mapas_Trasporte_Fktransportes]
GO
ALTER TABLE [dbo].[PuntoTransitado]  WITH CHECK ADD  CONSTRAINT [FK_PuntoTransitado_PuntoInteres_FkPunto] FOREIGN KEY([FkPunto])
REFERENCES [dbo].[PuntoInteres] ([PkPunto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PuntoTransitado] CHECK CONSTRAINT [FK_PuntoTransitado_PuntoInteres_FkPunto]
GO
ALTER TABLE [dbo].[PuntoTransitado]  WITH CHECK ADD  CONSTRAINT [FK_PuntoTransitado_Trasporte_FkTransporte] FOREIGN KEY([FkTransporte])
REFERENCES [dbo].[Trasporte] ([PkTransporte])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PuntoTransitado] CHECK CONSTRAINT [FK_PuntoTransitado_Trasporte_FkTransporte]
GO
ALTER TABLE [dbo].[Trasporte]  WITH CHECK ADD  CONSTRAINT [FK_Trasporte_TipoTrasporte_FkTipo] FOREIGN KEY([FkTipo])
REFERENCES [dbo].[TipoTrasporte] ([PkTipo])
GO
ALTER TABLE [dbo].[Trasporte] CHECK CONSTRAINT [FK_Trasporte_TipoTrasporte_FkTipo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Roles_RolPkRol] FOREIGN KEY([RolPkRol])
REFERENCES [dbo].[Roles] ([PkRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Roles_RolPkRol]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteRuta]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Sp_DeleteRuta]
@PkTransporte int
AS
BEGIN

delete 
from [dbo].[Trasporte]
where @PkTransporte=PkTransporte
END

-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Sp_IngresarRuta]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Sp_IngresarRuta]
@Nombre varchar(50),
@HoraInicial varchar(5),
@HoraFinal varchar(5),
@Dia varchar(50),
@Estatus bit,
@FkTipo int
AS
BEGIN
insert into Trasporte values(@Nombre,@HoraInicial,@HoraFinal,@Dia,@Estatus,@FkTipo)
END
-----------------------------

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteMapas]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpDeleteMapas]
@PkMapas int,
@MapaUrl varchar(Max),
@Fktransportes int
AS
BEGIN
delete from [dbo].[Mapas] where @PkMapas=PkMapas
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUsuarios]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteUsuarios]
@PkUser int
as
begin
    delete from Usuario where @PkUser = PkUser
end
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpGetMapas]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpGetMapas]
AS
BEGIN
	select* from [dbo].[Mapas]
END
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpGetTrasporte]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetTrasporte]
AS
BEGIN
select * from [dbo].[Trasporte]
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetUsuarios]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpGetUsuarios]
AS
BEGIN
select * from Usuario
END
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpInsertMapas]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpInsertMapas]
@MapaUrl varchar(Max),
@Fktransportes int
AS
BEGIN
insert into [dbo].[Mapas]values (@MapaUrl,@Fktransportes)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertUsuarios]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SpInsertUsuarios]
@Nombre varchar (max),
@Nickname varchar(max),
@Password varchar(max),
@FkRol int,
@RolPkRol int
AS
BEGIN
insert into Usuario values (@Nombre,@Nickname,@Password,@FkRol,@RolPkRol)
END
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpLeerCombi]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcum>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SpLeerCombi]
AS
BEGIN

select * from Trasporte
END
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpMapaGet]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpMapaGet]
@Fktransportes int
AS
BEGIN
select * from Mapas where @Fktransportes=Fktransportes
END
GO
/****** Object:  StoredProcedure [dbo].[SpUpdateMapas]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpUpdateMapas]
@PkMapas int,
@MapaUrl varchar(Max),
@Fktransportes int
AS
BEGIN
update [dbo].[Mapas]
set MapaUrl=@MapaUrl,Fktransportes=@Fktransportes
where PkMapas=@PkMapas
END
GO
/****** Object:  StoredProcedure [dbo].[SpUpdateRuta]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpUpdateRuta] 
@PkTransporte int,
@Nombre varchar(Max),
@HoraInicial varchar(Max),
@HoraFinal varchar(Max),
@Dia varchar(Max),
@Estatus bit,
@FkTipo int
AS
BEGIN
 
Update [dbo].[Trasporte]
set Nombre=@Nombre, HoraInicial=@HoraInicial,HoraFinal= @HoraFinal,
Dia= @Dia,Estatus= @Estatus,FkTipo	= @FkTipo
where @PkTransporte =PkTransporte 
END
-----------------------------
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SpUpdateUsuario]    Script Date: 30/11/2022 08:13:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpUpdateUsuario]
@PkUser int,
@Nombre varchar (max),
@Nickname varchar(max),
@Password varchar(max),
@FkRol int,
@RolPkRol int
AS
BEGIN

update [dbo].[Usuario]
set Nombre=@Nombre,Nickname=@Nickname,Usuario.Password=@Password,FkRol=@FkRol,RolPkRol=@FkRol
where PkUser=@PkUser
END
GO
