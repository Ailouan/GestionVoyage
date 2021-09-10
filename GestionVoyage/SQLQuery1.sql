create database GestionVoyage
use GestionVoyage

create table Passengers(
Id int primary key,
Nom varchar(20),
Passeport varchar(20),
Adresse varchar(20),
Nationalite varchar(20),
Sexe varchar(20),
Tele varchar(20))


select * from Vol

insert into Vol values ('j1234','fes','paris','23/07/2020',200)
insert into Vol values ('k1234','fes','paris','23/07/2020',200)
insert into Vol values ('j1434','fes','paris','23/07/2020',200)

create table Vol(
Vcode varchar(20)primary key,
Villedepart varchar(20),
VilleArrivee varchar(20),
Datee date,
Nbrplaces int)

delete from Vol where Vcode='j1234'

insert into Ticket values();
create table Ticket(
Tid int primary key,
Vcode varchar(20) foreign key references Vol(Vcode) on update cascade on delete cascade,
Id int foreign key references Passengers(Id) on update cascade on delete cascade,
Nom varchar(20),
Passeport varchar(20),
Nationalite varchar(20),
Prix float)

delete Ticket where Tid
select * from Vol
insert into Annulation values(1,1,'j1234','20/03/2020')

drop table Annulation

create table Annulation(
id int primary key,
Tid int foreign key references Ticket(Tid) on update cascade on delete cascade,
Vcode varchar(20) foreign key references Vol(Vcode),
Annuldate date)


insert into Passengers values(1,'amine','ab1234','narjis','Marocain','M','067543219')
insert into Passengers values(2,'adnane','cd22334','park','Francais','M','069785534')
insert into Passengers values(3,'salma','cb09876','one','italienne','F','0675643212')


select * from Passengers where id ='5'

