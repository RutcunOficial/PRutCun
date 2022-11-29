USE [Rutcun]
insert into Roles values('Admin')
insert into Usuario Values('Admin','Admin','123',1,1)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE Sp_DeleteRuta
@PkTrasporte int
AS
BEGIN

delete 
from [dbo].[Trasporte]
where @PkTrasporte=PkTrasporte
END

-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE Sp_IngresarRuta
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
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcum>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE Sp_LeerCombi
@PkTras int =null
AS
BEGIN

select * from Trasporte where @PkTras=PkTrasporte or @PkTras is null
END
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Sp_UpdateRuta] 
@PkTrasporte int,
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
where @PkTrasporte =PkTrasporte 
END
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE Sp_UpdateRuta
@PkTrasporte int,
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
where @PkTrasporte =PkTrasporte 
END
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure spDeleteUsuarios
@PkUser int
as
begin
    delete from Usuario where @PkUser = PkUser
end
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE SpGetMapas
AS
BEGIN
	select* from [dbo].[Mapas]
END
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE SpGetUsuarios
AS
BEGIN
select * from Usuario
END
-----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE SpInsertUsuarios
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
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE SpUpdateUsuario
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
-----------------------------
CREATE PROCEDURE SpGetDatosT
@id int =null

AS
BEGIN
    Select t5.Nombre as interes,t3.Nombre as calle,t1.Nombre as NombreRuta ,t1.Dia,t1.Estatus,t1.HoraInicial,t1.HoraFinal
From Trasporte as t1
 join CalleTransitada as t2 on t2.FkTrasporte=t1.PkTrasporte
left join Calle as t3 on t3.PkCalle=t2.FkCalle
inner join PuntoTransitado as t4 on t4.FkTrasporte=t1.PkTrasporte
right join PuntoInteres as t5 on t5.PkPunto=t4.FkPunto
where @id=t1.PkTrasporte or @id is null
END
GO