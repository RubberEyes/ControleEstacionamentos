--CREATE DATABASE BDEstacionamentos
--USE BDEstacionamentos

--DROP DATABASE BDEstacionamentos

CREATE TABLE Pessoas
(
	id int not null primary key identity,
	nome varchar(60) not null,
	[status] int null,
)

CREATE TABLE Funcionarios
(
	senha varchar(50) not null,
	cpf varchar(11) not null unique,
    previlegios int not null,
	pessoa_id int foreign key references Pessoas(id),
)

CREATE TABLE Estacionamentos
(
	cnpj varchar(14) not null unique,
	Endereco varchar(MAX) not null,
	pessoa_id int foreign key references Pessoas(id),
)

CREATE TABLE FuncionarioEstacionamento
(
	funcionarioId int foreign key references Pessoas(id),
	estacionamentoId int foreign key references Pessoas(id)
)

CREATE TABLE Vagas
(
	id int not null primary key identity,
    ocupacao bit not null,
	status int null
)

CREATE TABLE Telefones
(
	id int not null primary key identity,
	telefone varchar(20) not null,
	status int null
)

CREATE TABLE EstacionamentoTel
(
	telefoneId int foreign key references Telefones(id),
	estacionamentoId int foreign key references Pessoas(id),
)

CREATE TABLE PossuiVaga
(
	vagaId int foreign key references Vagas(id),
	estacionamentoId int foreign key references Pessoas(id)
)
