select p.idRol, p.descripcion from Permiso p
inner join Rol r on r.idRol=p.idRol
inner join Usuario u on u.idRol = r.idRol
where u.idUsuario =2

select * from Usuario
select * from Permiso
delete from Permiso

insert into Permiso(idRol, descripcion) 
values(1,'user'),
(1,'mante'),
(1,'client'),
(1,'ventas'),
(1,'button6')

insert into Permiso(idRol, descripcion) values
(2,'ventas'),
(2,'repote')



select * from Usuario

select * from Rol
insert into Rol (descripcion) values ('Administrador')
insert into Rol (descripcion) values ('Cliente')

use catedraPOO
insert into Usuario(documento, nombre,correo,clave,idRol,estado)
values ('MarDiaz', 'ADMIN', '@gmail.com','123',1,1)

insert into Usuario(documento, nombre,correo,clave,idRol,estado)
values ('Susana', 'SUSANA MEJIA', '@gmail.com','321',2,1)

select idUsuario,documento,nombre,correo,clave,estado from Usuario

select idRol, descripcion from Permiso
select idUsuario,documento,nombre,correo,clave,idRol, estado from Usuario
insert into Permiso(idRol, descripcion) 
values(1,'user'),
(1,'mante'),
(1,'client'),
(1,'ventas'),
(1,'repote')

insert into Permiso(idRol, descripcion) values
(2,'ventas'),
(2,'repote')

delete from Permiso

select p.idRol, p.descripcion from Permiso p
inner join Rol r on r.idRol=p.idRol
inner join Usuario u on u.idRol = r.idRol
where u.idUsuario =1

select idRol, descripcion from Rol

select u.idUsuario,u.documento,u.nombre,u.correo,u.clave,u.estado, r.idRol, r.descripcion  from Usuario u
inner join Rol r on r.idRol =u.idRol

update Usuario set estado = 0 where idUsuario=2

use catedraPOO

select idCategoria,descripcion,estado from Categoria


insert into Categoria(descripcion, estado) values
('ACCION',1),
('AVENTURA',1),
('PELEA',1)

delete from Categoria

		delete  from Categoria where idCategoria = 18  


		-- datos para los productos ------------------------------------------------------------------

select * from Juegos

select idJuego, codigo, nombre,descripcion,idCategoria,estado,strock,precioVenta from Juegos

insert into Juegos(codigo,nombre,descripcion,idCategoria,estado,strock,precioVenta) values
('258','mario kart','juego de aventura',15,1,20,10)

select idJuego,codigo,nombre, j.descripcion,c.idCategoria , c.descripcion[DescripcionCategoria], strock,precioVenta, j.estado from Juegos j
inner join Categoria c on c.idCategoria=j.idCategoria


select u.idUsuario,u.documento,u.nombre,u.correo,u.clave,u.estado, r.idRol, r.descripcion  from Usuario u
                    inner join Rol r on r.idRol =u.idRol

insert into Juegos(codigo,nombre,descripcion,idCategoria,strock,precioVenta ,estado) 
		values ('123','gogo','jojo',15,2,'20.5',1)