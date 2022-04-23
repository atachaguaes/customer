use master
go

create database Customers
go

use Customers
go


create table Customer
(
IdCustomer int identity primary key not null,
Names varchar(30) not null,
LastName varchar(30) not null,
DNI varchar(8) not null,
Email varchar(30) not null,
)
go

create procedure sp_SelectCustomerByIdCustomer
@IdCustomer int
as
select [IdCustomer], [Names], [LastName], [DNI], [Email]
from Customer 
where IdCustomer = @IdCustomer 
go

create procedure sp_SelectCustomer
as
select [IdCustomer], [Names], [LastName], [DNI], [Email]
from Customer
go

create procedure sp_InsertCustomer
@Names varchar(30),
@LastName varchar(30),
@DNI varchar(8),
@Email varchar(30),
@Resultado int output,
@Mensaje varchar(500) output
as
set @Resultado=0
if(not exists(select * from Customer where DNI=@DNI))
	if(not exists(select * from Customer where Email=@Email))
		begin
			insert Customer values (@Names, @LastName, @DNI, @Email)
			set @Resultado=SCOPE_IDENTITY()
		end
	else
		set @Mensaje='El Email ya existe en la tabla customer'
else
	set @Mensaje='El DNI ya existe en la tabla customer'
go

create procedure sp_UpdateCustomer
@IdCustomer int,
@Names varchar(30),
@LastName varchar(30),
@DNI varchar(8),
@Email varchar(30),
@Resultado int output,
@Mensaje varchar(500) output
as
set @Resultado=0
if(not exists(select * from Customer where DNI=@DNI and IdCustomer<>@IdCustomer))
	if(not exists(select * from Customer where Email=@Email and IdCustomer<>@IdCustomer))
		begin
			update Customer set Names=@Names, LastName=@LastName, DNI=@DNI, Email=@Email
			where IdCustomer=@IdCustomer
			set @Resultado=1
		end
	else
		set @Mensaje='El Email ya existe en la tabla customer'
else
	set @Mensaje='El DNI ya existe en la tabla customer'
go

create procedure sp_DeleteCustomer
@IdCustomer int,
@Resultado int output
as
set @Resultado=0
delete Customer where IdCustomer=@IdCustomer
set @Resultado=1
go







