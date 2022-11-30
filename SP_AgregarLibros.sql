alter proc SP_AgregarLibros
@nombre as varchar(30),
@genero as varchar(30),
@precio as int
as begin try
if((select count(*) from libros where nombre = @nombre) = 0 and @precio > 0)
insert into libros values (@nombre,@genero,@precio,1)
else if((select cantidad from libros where nombre = @nombre) >= 1 and @precio > 0)
update libros set cantidad = cantidad + 1 where nombre = @nombre
else if(@precio = 0)
raiserror('error',16,1)
end try
begin catch
raiserror('error',16,1)
end catch