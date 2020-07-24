create table Funcionario(
	  IdFuncionario		integer				identity(1,1)
	, Nome				nvarchar(150)		not null
	, Salario			decimal(18,2)		not null
	, DataAdmissao		datetime			not null
	, primary key(IdFuncionario)
)


create table Dependente(
	  IdDependente		integer				identity(1,1)
	, Nome				nvarchar(150)		not null
	, DataNascimento	date				not null
	, IdFuncionario		integer				not null
	, primary key(IdDependente)
	, foreign key(IdFuncionario)
		references Funcionario(IdFuncionario)
)