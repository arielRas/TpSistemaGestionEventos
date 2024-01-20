USE DbGestionEventos;
GO

CREATE PROCEDURE SP_NUEVO_USUARIO(
	@nombre VARCHAR(50),
	@apellido VARCHAR(30),
	@email VARCHAR(50),
	@idProvincia INT,
	@direccion VARCHAR(100),
	@telefono VARCHAR(10),
	@dni BIGINT,
	@esProveedor BIT,
	@salt VARBINARY,
	@password VARBINARY
	)
AS BEGIN
	DECLARE @id UNIQUEIDENTIFIER = NEWID();

	IF @esProveedor = 0
		BEGIN
		BEGIN TRANSACTION
			INSERT INTO ORGANIZADOR VALUES(@id, @nombre, @apellido, @email, @dni, @telefono, @idProvincia, @direccion);
			INSERT INTO CREDENCIALES VALUES(@id, @salt, @password);	
		COMMIT TRANSACTION
		END
	ELSE
		BEGIN
		BEGIN TRANSACTION
			INSERT INTO PROVEEDOR VALUES(@id, @nombre, @apellido, @email, @dni, @telefono, @idProvincia, @direccion, DEFAULT);
			INSERT INTO CREDENCIALES VALUES(@id, @salt, @password);	
		COMMIT TRANSACTION
		END
END