/*
CREATE database reactCore;

use reactCore;

CREATE TABLE Rol(
    Rol_Id int identity,
    rol_name varchar(100),
    Status int,
    primary key(Rol_Id)
);

CREATE TABLE Users(
    User_Id int identity,
    user_name varchar(100),
    last_name varchar(100),
    discharge_date datetime,
    age int,
    Rol_Id int,
    Status int,
    primary key(User_Id),
    constraint Rol_Id foreign key(Rol_Id)
    references Rol(Rol_Id)
);


Insert into Rol(rol_name, Status) values 
                                        ('Reportes',1),
                                        ('AdminIT', 0),
                                        ('SupervisorCompras', 1), 
                                        ('SupervisorVentas', 1);
--exec RolSP 'U', 1, 'Reportes', 1;
--exec UsersSP 'I', 0, 'Jean Gray', 'dos', '2020/10/10', 24, 1, 1;
*/