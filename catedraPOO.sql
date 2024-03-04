use catedraPOO
go

create table Rol(
idRol int primary key identity,
descripcion varchar(50),
fechaRegistro datetime default getdate() 
)

go

create table Permiso(
idPermiso int primary key identity,
idRol int references Rol(idRol),
descripcion varchar(50),
fechaRegistro datetime default getdate() 
)
go
create table Cliente (
idCliente int primary key identity,
documento varchar(50),
nombre varchar (50),
correo varchar(50),
telefono varchar(50),
estado bit,
fechaRegistro datetime default getdate() 
)
go
create table Usuario(
idUsuario int primary key identity,
documento varchar(50),
nombre varchar (50),
correo varchar(50),
clave varchar(50),
idRol int references Rol(idRol),
estado bit,
fechaRegistro datetime default getdate() 
)
go

create table Categoria(
idCategoria int primary key identity,
descripcion varchar(100),
estado bit,
fechaRegistro datetime default getdate() 
)
go
create table Juegos(
idJuego int primary key identity,
codigo varchar(50),
nombre varchar(50),
descripcion varchar(50),
idCategoria int references Categoria(idCategoria),
strock int not null default 0,
precioVenta decimal(10,2) default 0,
estado bit,
fechaRegistro datetime default getdate()
)
go

create table Compra(
idCompra int primary key identity,
idUsuario int references Usuario(idUsuario),
tipoDocumento varchar(50),
correo varchar(50),
montoTotal decimal(10,2),
fechaRegistro datetime default getdate()
)
go

create table Detalle_Compra(
idDetalleCompra int primary key identity,
idCompra int references Compra(idCompra),
idJuego int references Juegos(idJuego),
precioVenta decimal(10,2) default 0,
cantidad int,
montoTotal decimal(10,2),
fechaRegistro datetime default getdate()
)
go

create table Venta(
idVenta int primary key identity,
idUsuario int references Usuario(idUsuario),
tipoDocumento varchar(50),
numDocumento varchar (50),
nombreCliente varchar(50),
montoPago decimal(10,2),
montoCambio decimal(10,2),
montoTotal decimal(10,2),
fechaRegistro datetime default getdate()
)
go


create table Detalle_Venta(
idDetalleVenta int primary key identity,
idVenta int references Venta(idVenta),
idJuego int references Juegos(idJuego),
precioVenta decimal(10,2) default 0,
cantidad int,
subtotal decimal(10,2),
fechaRegistro datetime default getdate()
)
