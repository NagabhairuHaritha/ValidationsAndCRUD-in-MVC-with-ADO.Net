create procedure DeleteEmployee
(
@EId int
)
as
begin
 delete from Employe where id=@EId
End