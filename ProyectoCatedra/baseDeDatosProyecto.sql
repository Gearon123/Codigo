create database tiendaJuegos
go
use tiendaJuegos
go

create table dimJuegos(
id int primary key,
nombre varchar(255),
categoria varchar(255),
descripcion varchar(1000))
go

ALTER TABLE dimJuegos
ADD precio decimal(10, 2);
go

create table dimAdmins(
id  INT PRIMARY KEY IDENTITY(1,1),
usuario varchar(50) not null,
contrasena varchar(255) not null)
go


CREATE TABLE dimCliente (
    id INT PRIMARY KEY IDENTITY(1,1),
    usuario VARCHAR(50) UNIQUE NOT NULL,
    nombres VARCHAR(255) NOT NULL,
    apellidos VARCHAR(255) NOT NULL,
    correo VARCHAR(255) UNIQUE NOT NULL,
    contrasena VARCHAR(255) NOT NULL
);
go

--Usuario para ingresar como admin--
INSERT INTO dimAdmins (usuario, contrasena)
VALUES ('admin', 'password123');


select * from dimCliente
select * from dimJuegos
select * from dimAdmins


