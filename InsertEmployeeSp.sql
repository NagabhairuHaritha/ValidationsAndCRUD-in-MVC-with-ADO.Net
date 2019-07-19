create procedure AddNewEmployee
(
@name varchar(50),
@salary money,
@contact varchar(50),
@adderess varchar(50),
@emailId varchar(50)
)
as
begin
 insert into Employe values(@name,@salary,@contact,@adderess,@emailId)
 End
