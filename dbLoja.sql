create database dbLoja;
use dbLoja;

create table Produto(
Prodid int primary key auto_increment,
Prodnome varchar (30) not null ,
Proddescr varchar(50) not null
);

create table Cliente(
CPF char(11) primary key,
Nome varchar(30) not null,
Endereco varchar (50) not null);

select * from cliente;