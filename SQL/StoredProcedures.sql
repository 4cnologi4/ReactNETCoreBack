------------------------------------SP para usuarios
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.UsersSP 
	-- Add the parameters for the stored procedure here
	@caso char,
	@UserId int,
	@user_name varchar(100),
    @last_name varchar(100),
    @discharge_date datetime,
    @age int,
    @Rol_Id int,
    @Status int
AS
BEGIN
	SET NOCOUNT ON;
	IF (@caso = 'I')
		BEGIN
		BEGIN TRANSACTION;
			INSERT INTO dbo.Users(user_name, last_name, discharge_date, age, Rol_Id, Status) 
			values(@user_name, @last_name, @discharge_date, @age, @Rol_Id, @Status);
		COMMIT;
		END
	ELSE IF (@caso = 'U')
	BEGIN
		BEGIN TRANSACTION;
			UPDATE dbo.Users SET 
			user_name = @user_name,
			last_name = @last_name, 
			discharge_date = @discharge_date, 
			age = @age, 
			Rol_Id = @Rol_Id,
			Status = @Status
			WHERE User_Id = @UserId;
		COMMIT;
	END
	ELSE IF (@caso = 'D')
	BEGIN
		BEGIN TRANSACTION;
			DELETE FROM dbo.Users WHERE User_Id = @UserId;
		COMMIT;
	END
END
GO


------------------------------------------------------SP para Roles
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.RolSP 
	@caso char,
    @Rol_Id int,
	@Rol_name varchar(100),
    @Status int
AS
BEGIN
	SET NOCOUNT ON;
	IF (@caso = 'I')
		BEGIN
		BEGIN TRANSACTION;
			INSERT INTO dbo.Rol(rol_name, Status) 
			values(@Rol_name, @Status);
		COMMIT;
		END
	ELSE IF (@caso = 'U')
	BEGIN
		BEGIN TRANSACTION;
			UPDATE dbo.Rol SET 
			rol_name = @Rol_name,
			Status = @Status
			WHERE Rol_Id = @Rol_Id;
		COMMIT;
	END
	ELSE IF (@caso = 'D')
	BEGIN
		BEGIN TRANSACTION;
			DELETE FROM dbo.Rol WHERE Rol_Id = @Rol_Id;
		COMMIT;
	END
END
GO
*/

