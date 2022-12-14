USE [Rutcun]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteRuta]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[Sp_IngresarRuta]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpDeleteMapas]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteUsuarios]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetMapas]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetTrasporte]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpGetUsuarios]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertMapas]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertUsuarios]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpLeerCombi]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpMapaGet]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpUpdateMapas]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpUpdateRuta]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[SpUpdateUsuario]    Script Date: 30/11/2022 08:14:42 p. m. ******/
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
-------------------------------------------------------------------------------------
insert into Roles values ('Admin')
insert into Usuario values('Admin','Admin','EkDZQ1TTR9U=',1,1)
insert into TipoTrasporte values('Combi')
insert into Trasporte values ('Ruta 14','05:00','00:00','Todos los dias',1,1)
insert into Trasporte values ('Ruta 11','05:00','00:00','Todos los dias',1,1)
insert into Trasporte values ('Ruta 21','05:00','00:00','Todos los dias',1,1)
insert into Mapas values ('https://www.google.com/maps/d/u/0/embed?mid=1EbUl4Y7hSngXrdD3lKHCUT5HOGhoSM4&ehbc=2E312F&ll=21.156593066590176%2C-86.87080499999999&z=14',1)
insert into Mapas values ('https://www.google.com/maps/d/u/0/embed?mid=1ud2gDIugV3PhlqFKlYGph2mtTb_BSJ8&ehbc=2E312F&ll=21.15536707616778%2C-86.85069499999997&z=13',3)
insert into Mapas values ('https://www.google.com/maps/d/u/0/embed?mid=1l1KJdva0mp-WxrvJHqon25yS9f0G89A&ehbc=2E312F&ll=21.163991399127358%2C-86.86828825&z=14',2)
insert into Calle values ('La talleres')
insert into Calle values ('La Chac-mool')
insert into CalleTransitada values(1,1)
insert into CalleTransitada values(2,2)
insert into CalleTransitada values(2,3)
Insert into PuntoInteres values('Chedraui de la talleres')
Insert into PuntoInteres values('La universidad politecnica de quintana roo')
Insert into PuntoInteres values('Plaza de las Americas ')
insert into PuntoTransitado values(1,1)
insert into PuntoTransitado values(2,2)
insert into PuntoTransitado values(3,3)

