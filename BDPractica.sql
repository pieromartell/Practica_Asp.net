drop database if exists BDPractica

create database BDPractica

use BDPractica;


create table TB_Asignatura(
	id_asig int primary key identity,
	descripcion varchar(50) not null,
	estado int not null
);

create table TB_LIBRO(
	Id_libro int primary key identity,
	descripcion varchar(50) not null,
	id_asing int not null,
	stock int not null
	constraint fk_asignatura_Key Foreign Key (id_asing) references TB_Asignatura(id_asig)
);

insert into TB_Asignatura values('Poesia', 1); 
insert into TB_Asignatura values('Ciencia', 1); 
insert into TB_Asignatura values('Teatro', 1); 
insert into TB_Asignatura values('Cuento', 1); 
insert into TB_Asignatura values('Novela', 1); 



insert into TB_LIBRO values('Rima',1,20);
insert into TB_LIBRO values('Pablo Neruda',1,20);
insert into TB_LIBRO values('Federico García Lorca',1,20);

insert into TB_LIBRO values('Cosmos',2,20);
insert into TB_LIBRO values('DNA',2,20);
insert into TB_LIBRO values('Hawking',2,20);

insert into TB_LIBRO values('Hamlet',3,20);
insert into TB_LIBRO values('Esperando Godot',3,20);
insert into TB_LIBRO values('García Lorca',3,20);

insert into TB_LIBRO values('Borges',4,20);
insert into TB_LIBRO values('Poe',4,20);
insert into TB_LIBRO values('García Lorca',4,20);

insert into TB_LIBRO values('1984',4,20);
insert into TB_LIBRO values('Cien años soledad',4,20);
insert into TB_LIBRO values('Eco',4,20);


select * from TB_Asignatura
select * from TB_LIBRO


create procedure Listar_Libro(
	@descripcion varchar(50) =  null
)
as
begin
	select * from TB_LIBRO where @descripcion = descripcion
End;


create procedure Insert_Libro(
	@descripcion varchar(50),
	@Id_asing int,
	@stock int
)
as 
begin
	Insert into TB_LIBRO values (@descripcion,@Id_asing,@stock)
END;

create procedure Insert_Asignatura(
	@descripcion varchar(50),
	@estado int
)
as 
begin
	Insert into TB_Asignatura values (@descripcion,@estado)
END;


create procedure Update_Asignatura(
@Id int,
@descripcion varchar(50),
@estado int
)
as 
begin 
	Update TB_Asignatura set descripcion = @descripcion,
	estado = @estado 
	where id_asig= @Id 
End;

create procedure Update_Libro(
@IdLibro int,
@descripcion varchar(50),
@IdAsigna int,
@stock int
)
as
begin
	update TB_LIBRO set descripcion = @descripcion,
	id_asing = @IdAsigna, stock = @stock where Id_libro = @IdLibro
END;

create procedure Delete_Asignatura(
	@Id int
)
as 
begin
	delete from TB_Asignatura where id_asig = @Id
End;

create procedure delete_Libro(
	@Id int
)
as 
begin
	delete from TB_LIBRO where Id_libro = @Id
END;

exec Listar_Libro @descripcion = 'Eco'
exec Listar_Libro '3'

exec Insert_Libro 'Teatro Novie',3,2

exec Insert_Asignatura 'Drama',0

exec delete_Libro 5

exec Delete_Asignatura 3

exec Update_Asignatura 1,'Ciencia Social',0

exec Update_Libro 3,'Colega Donde esta mi Urbe',1,30



