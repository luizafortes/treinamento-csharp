create table Cliente(
	IdCliente		integer			identity(1,1),
	Nome			nvarchar(150)	not null,
	Cpf				nvarchar(11)	not null unique,
	Email			nvarchar(100)	not null unique,
	DataCriacao		datetime		not null,
	primary key(IdCliente))
go

select * from cliente

go

create procedure SP_InserirCliente(
	@Nome		nvarchar(150),
	@Cpf		nvarchar(11),
	@Email		nvarchar(100)
	)
as
begin

	insert into Cliente(Nome, Cpf, Email, DataCriacao)
	values(@Nome, @Cpf, @Email, GetDate())

end
go

create procedure SP_AlterarCliente(
	@IdCliente	int,
	@Nome		nvarchar(150),
	@Cpf		nvarchar(11),
	@Email		nvarchar(100)
	)
as
begin

update 
	Cliente 
	set 
		Nome = @Nome, 
		Cpf = @Cpf, 
		Email = @Email
	where
		IdCliente = @IdCliente

end
go

create procedure SP_ExcluirCliente(
	@IdCliente	int
	)
as
begin

delete from	Cliente where IdCliente = @IdCliente

end
go

create procedure SP_ConsultarCliente as
begin
	select * from Cliente 
end
go

create procedure SP_ObterClientePorId(
	@IdCliente	int
	)
as
begin
	select * from Cliente where IdCliente = @IdCliente
end
go

create procedure SP_ObterClientePorCpf(	
	@Cpf		nvarchar(11)
	)
as
begin
	select * from Cliente where Cpf = @Cpf
end
go

create procedure SP_ObterClientePorEmail(	
	@Email		nvarchar(100)
	)
as
begin
	select * from Cliente where Email = @Email
end
go
