create database SegurosIrapuato

use SegurosIrapuato

create table Ajustador
(
 ID_Aj int primary key not null,
 Nombre varchar(30) not null,
)

create table Cliente
(
 ID_C int primary key not null,
 Nombre varchar(30)not null, 
 Direccion varchar(50) not null,
 Telefono int not null,
 Aj_ID int foreign key (Aj_ID) REFERENCES Ajustador (ID_Aj) not null
)

create table Autos
(
 ID_A int not null primary key ,
 Marca varchar(20) not null,
 Modelo varchar(20) not null,
 Año int not null,
 Kilometraje float not null,
 Placas varchar(20) not null,
 Tazaf varchar(20) not null,
 Estado varchar(20) not null,
 C_ID int foreign key (C_ID) REFERENCES Cliente (ID_C) not null,
 Poliza varchar(20) not null,
)

create table Siniestro
(
 ID_S int primary key not null,
 Costo varchar(20) not null,
 Fecha varchar(20) not null,
 N_Estado varchar(20) not null,
 A_ID int foreign key (A_ID) REFERENCES Autos (ID_A) not null,
 Aj_ID int foreign key (Aj_ID) REFERENCES Ajustador (ID_Aj) not null
)
