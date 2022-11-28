USE [Rutcun]
insert into Roles values('Admin')
insert into Usuario Values('Admin','Admin','123',1)

GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteRuta]    Script Date: 16/11/2022 08:08:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_DeleteRuta]
@PkTras int
AS
BEGIN

delete 
from [dbo].[Trasporte]
where @PkTras=PkTrasporte

select * from Trasporte
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_IngresarRuta]    Script Date: 16/11/2022 08:08:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_IngresarRuta]
@Nombre varchar(50),
@HoraInicio varchar(5),
@HoraFinal varchar(5),
@Dia varchar(50),
@Estatus bit,
@tipo int
AS
BEGIN
 
insert into Trasporte values(@Nombre,@HoraInicio,@HoraFinal,@Dia,@Estatus,@tipo)
declare
@pkTras int 

select @pkTras=MAX(PkTrasporte) from Trasporte 
Select * from Trasporte where @pkTras=PkTrasporte
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_LeerCombi]    Script Date: 16/11/2022 08:08:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcum>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_LeerCombi]
@PkTras int =null
AS
BEGIN

select * from Trasporte where @PkTras=PkTrasporte or @PkTras is null
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateRuta]    Script Date: 16/11/2022 08:08:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Rutcun>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_UpdateRuta] 
@Nombre varchar(50),
@HoraInicio varchar(5),
@HoraFinal varchar(5),
@Dia varchar(50),
@Estatus bit,
@tipo int,
@Actualizar int
AS
BEGIN
 
Update [dbo].[Trasporte]
set Nombre=@Nombre, HoraInicial=@HoraInicio,HoraFinal= @HoraFinal,
Dia= @Dia,Estatus= @Estatus,FkTipo= @tipo
where @Actualizar =PkTrasporte 


Select * from Trasporte where @Actualizar=PkTrasporte
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpGetUsuarios
AS
BEGIN
select * from Usuario
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpInsertUsuarios
@Nombre varchar (max),
@Nickname varchar(max),
@Password varchar(max),
@FkRol int
AS
BEGIN
insert into Usuario values (@Nombre,@Nickname,@Password,@FkRol )
END
GO

