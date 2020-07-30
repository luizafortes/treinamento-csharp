create table Cliente(
	IdCliente		integer			identity(1,1),
	Nome			nvarchar(150)	not null,
	Email			nvarchar(150)	not null unique,
	Cpf				nvarchar(15)	not null unique,
	primary key(IdCliente))

create table Dependente(
	IdDependente	integer			identity(1,1),
	Nome			nvarchar(150)	not null,
	DataNascimento	date			not null,
	IdCliente		integer			not null,
	primary key(IdDependente),
	foreign key(IdCliente)
		references Cliente(IdCliente))

