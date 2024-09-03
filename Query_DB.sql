-- Base De Datos
CREATE DATABASE DBPRUEBAS
Go

USE DBPRUEBAS
GO

-- Tabla 1: USUARIO
create table USUARIO
(
IdUsuario int primary key identity(1,1),
DocumentoIdentidad varchar(60),
Nombres varchar(60),
Telefono varchar(60),
Correo varchar(60),
Ciudad varchar(60),
FechaRegistro datetime default getdate()
)
go


-- Insertando Registros En La Tabla: --
---------------------------------------
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad]) VALUES (1, N'32504112', N'Regina', N'690577998', N'blandit.mattis@eratvolutpat.edu', N'Rae Lakes')
INSERT [dbo].[USUARIO] ([IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad]) VALUES (2, N'20427780', N'Macy', N'270411465', N'interdum@id.net', N'Treppo Carnico')
INSERT [dbo].[USUARIO] ([IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad]) VALUES (3, N'47714668', N'Sophia', N'757428589', N'mattis.semper.dui@nibhPhasellusnulla.net', N'Levin')
INSERT [dbo].[USUARIO] ([IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad]) VALUES (4, N'32493629', N'Rhiannon', N'794799685', N'posuere@Morbinon.edu', N'Hearst')
INSERT [dbo].[USUARIO] ([IdUsuario], [DocumentoIdentidad], [Nombres], [Telefono], [Correo], [Ciudad]) VALUES (5, N'22383970', N'Aubrey', N'711648390', N'odio@arcuVestibulumante.edu', N'Baltasound')

SET IDENTITY_INSERT [dbo].[USUARIO] OFF



-- Procedimientos De Almacenados: --
--********************************--

-- PROCEDIMIENTO CREAR:
-----------------------
Create Procedure usp_registrar
(
@documentoidentidad varchar(60),
@nombres varchar(60),
@telefono varchar(60),
@correo varchar(60),
@ciudad varchar(60)
)
as
begin
--Insertamos Los Parametros Recibidos
insert into USUARIO(DocumentoIdentidad,Nombres,Telefono,Correo,Ciudad)
values(@documentoidentidad,@nombres,@telefono,@correo,@ciudad)
end
Go


-- PROCEDIMIENTO EDITAR:
------------------------
Create Procedure usp_modificar
(
@idusuario int,
@documentoidentidad varchar(60),
@nombres varchar(60),
@telefono varchar(60),
@correo varchar(60),
@ciudad varchar(60)
)
as
begin
-- Modificamos Los Atributos Con Los Parametros:
update USUARIO set 
DocumentoIdentidad = @documentoidentidad,
Nombres = @nombres,
Telefono = @telefono,
Correo = @correo,
Ciudad = @ciudad
where IdUsuario = @idusuario
end
Go


-- PROCEDIMIENTO OBTENER POR ID:
--------------------------------
Create Procedure usp_obtener(@idusuario int)
as
begin
-- Buscamos Ese Registro Con Ese ID:
select * from usuario where IdUsuario = @idusuario
end
Go


-- PROCEDIMIENTO OBTENER TODOS LOS REGISTROS:
---------------------------------------------
Create Procedure usp_listar
as
begin
-- Obtenemos Todos Los Registros
select * from usuario
end
Go


-- PROCEDIMIENTO ELIMINAR POR ID:
Create Procedure usp_eliminar(@idusuario int)
as
begin
-- Buscamos ese registro por su ID y lo eliminamos
delete from usuario where IdUsuario = @idusuario
end
Go


