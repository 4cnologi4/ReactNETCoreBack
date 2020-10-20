/*
CREATE VIEW getRolView AS
  SELECT 
	  Rol_Id, 
	  rol_name, 
	  Status
  FROM dbo.Rol;


select * from getRolView;


CREATE VIEW getInfoUserView AS
select U.User_Id,
    U.user_name,
    U.last_name,
    U.discharge_date,
    U.age,
    U.Rol_Id,
	R.rol_name,
    U.Status
	FROM Users as U
	JOIN Rol AS R ON U.Rol_Id = R.Rol_Id;

select * from getInfoUserView;

*/