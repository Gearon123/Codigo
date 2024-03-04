
--Validaciones Parametrisadas para registro
create PROC SP_REGISTRARUSUARIO(
@documento varchar(50),
@nombre varchar(100),
@correo varchar(50),
@clave varchar(50),
@idRol int,
@Estado bit,
@idUsuarioResultado int out,
@Mensaje varchar (500) output
)
as
begin
	set @idUsuarioResultado=0
	set @Mensaje = ''
	if not exists(select * from Usuario where documento = @documento)
	begin
		insert into Usuario(documento,nombre,correo,clave,idRol,estado) 
		values (@documento,@nombre,@correo,@clave,@idRol,@Estado)
		set @idUsuarioResultado= SCOPE_IDENTITY()

end
else
	set @Mensaje = 'No se puede repetir el usuario'
end

declare @idUsuarioGenerado int 
declare @mensaje varchar(500)
exec SP_REGISTRARUSUARIO '123', 'ANA KATHERINE','ana@gmail.com','159',2,1,@idUsuarioGenerado output, @Mensaje output

select @idUsuarioGenerado
select @Mensaje

go
--Validaciones Parametrisadas para actualizar
create PROC SP_ActualizarUSUARIO(
@idUsuario int,
@documento varchar(50),
@nombre varchar(100),
@correo varchar(50),
@clave varchar(50),
@idRol int,
@Estado bit,
@respuesta bit out,
@Mensaje varchar (500) output
)
as
begin
	set @respuesta=0
	set @Mensaje = ''
	if not exists(select * from Usuario where documento = @documento and idUsuario != @idUsuario)
	begin
		update Usuario set 
		documento=@documento,
		nombre=@nombre,
		correo=@correo,
		clave=@clave,
		idRol=@idRol,
		estado=@Estado 
		where idUsuario= @idUsuario


		set @respuesta= 1

end
else
	set @Mensaje = 'No se puede repetir el usuario'
end




declare @respuesta bit 
declare @mensaje varchar(500)
exec SP_ActualizarUSUARIO 3, 'kathy', 'ANA KATHERINE','ana@gmail.com','159',2,1,@respuesta output, @Mensaje output

select @respuesta
select @Mensaje
select * from Usuario


--Validaciones Parametrisadas para eliminar 
create PROC SP_ELIMINARUSUARIO(
@idUsuario int,
@respuesta bit output,
@Mensaje varchar (500) output
)
as
begin
	set @respuesta=0
	set @Mensaje = ''
	declare @pasoreglas bit =1

	if EXISTS (select * from Venta v
	inner join Usuario u on u.idUsuario = v.idUsuario
	where u.idUsuario=@idUsuario)
	begin
		set @pasoreglas=0
		set @respuesta =0
		set @Mensaje= @Mensaje+'no se puede eliminar porque tiene una venta '
	end

	if(@pasoreglas =1)
	begin 
		delete FROM Usuario where idUsuario= @idUsuario
		set @respuesta =1
	end
end




declare @respuesta bit 
declare @mensaje varchar(500)
exec SP_ActualizarUSUARIO 3, 'kathy', 'ANA KATHERINE','ana@gmail.com','159',2,1,@respuesta output, @Mensaje output

select @respuesta
select @Mensaje
select * from Usuario

--validaciones para categorias-------------------------------------------------------------------------------------------------------------------------------

--CREAR VALIDACIONES PARA LAS CATEGORIAS
create PROC SP_REGISTRARCATEGORIA(
@descripcion varchar(50),
@Estado bit,
@Mensaje varchar(500) output,
@Resultado int out
)
as
begin
	set @Resultado=0
	if not exists(select * from Categoria where descripcion = @descripcion)
	begin
		insert into Categoria(descripcion, estado) 
		values (@descripcion,@Estado)
		set @Resultado= SCOPE_IDENTITY()

end
else
	set @Mensaje = 'No se puede repetir la descripcion de categoria'
end

go
--editar categoria------------------------------
create PROC SP_ACTUALIZARCATEGORIA(
@idCategoria int,
@descripcion varchar(50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado=1
	if not exists(select * from Categoria where descripcion = @descripcion and idCategoria !=@idCategoria)

		update Categoria set  
		descripcion = @descripcion,
		estado =@Estado		
		where idCategoria = @idCategoria
else
begin 
	set @Resultado =0
	set @Mensaje = 'No se puede repetir la descripcion de categoria'
end
end

go


--Eliminar categoria
create PROC SP_ELIMINARCATEGORIA(
@idCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado=1
	if not exists(
		select * from Categoria c
		inner join Juegos p on p.idCategoria= c.idCategoria
		where c.idCategoria= @idCategoria
	)
	begin 
		delete  from Categoria where idCategoria = @idCategoria  
		end
else
begin 
	set @Resultado =0
	set @Mensaje = 'la categoria se encuentra relacionanda a un juego '
end
end

--validaciones para productos-------------------------------------------------------------------------------------------------------------------------------

--CREAR VALIDACIONES PARA LAS PRODUCTOS
create PROC SP_REGISTRARPRODUCTO(
@codigo varchar(20),
@nombre varchar(50),
@descripcion varchar(50),
@IdCategoria int,
@strock int,
@precio int,
@Estado bit,
@Mensaje varchar(500) output,
@Resultado int out
)
as
begin
	set @Resultado=0
	if not exists(select * from Juegos where codigo = @codigo)
	begin
		insert into Juegos(codigo,nombre,descripcion,idCategoria,strock,precioVenta ,estado) 
		values (@codigo,@nombre,@descripcion,@IdCategoria,@strock,@precio,@Estado)
		set @Resultado= SCOPE_IDENTITY()

end
else
	set @Mensaje = 'No se puede repetir el producto'
end
USE catedraPOO
go
--editar categoria------------------------------
create PROC SP_ACTUALIZARPRODUCTO(
@idJuego int,
@codigo varchar(20),
@nombre varchar(50),
@descripcion varchar(50),
@IdCategoria int,
@strock int,
@precio int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado=1
	if not exists(select * from Juegos where codigo = @codigo and idJuego !=@idJuego)

		update Juegos set  
		codigo = @codigo,
		nombre = @nombre,
		descripcion = @descripcion,
		strock = @strock,
		precioVenta=@precio,
		idCategoria = @IdCategoria,
		estado =@Estado		
		where idJuego = @idJuego
else
begin 
	set @Resultado =0
	set @Mensaje = 'Ya existe un producto con el mismo codigo'
end
end

go

--Eliminar categoria
create PROC SP_ELIMINARProducto(
@idJuego int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado=0
	set @Mensaje = ''
	declare @pasoreglas bit =1

	if exists(Select * from Detalle_Compra dc
		inner join Juegos j on j.idJuego= dc.idJuego
		where j.idJuego=@idJuego
	)
	begin 
		set @pasoreglas= 0
		set @Resultado=0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque tiene una compra'
	end
	if(@pasoreglas=1)
	begin
	delete from Juegos where idJuego =@idJuego
	set @Resultado =1

end
end