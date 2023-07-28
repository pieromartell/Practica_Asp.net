drop database if Exists PCPruebaBD
go

create database PCPruebaBD
go

use PCPruebaBD
create table Brand(
	BrandID int primary Key Identity,
	Name varchar(50) not null
)
go

create table PC(
	PCID int primary key Identity,
	NamePC varchar(50),
	BrandID int not null,
	constraint Foreign_Key_PC  Foreign Key(BrandID) references Brand(BrandID)
)

insert into Brand values ('LG');
insert into Brand values ('LG2');
insert into Brand values ('LG3');
select * from Brand

insert into PC values('PC PIERO','1')
go
insert into PC values('PC Carlos','2')
go

select * from PC

use master