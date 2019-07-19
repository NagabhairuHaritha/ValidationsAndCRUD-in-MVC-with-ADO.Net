create procedure UpdateEmployee
(  
   @EId int,  
   @name varchar(50),  
   @salary money,  
   @contact varchar(50),
   @adderess varchar(50),
   @emailId varchar(50)
)  
as  
begin  
   Update Employe   
   set
   name=@name,  
   salary=@salary, 
   contact=@contact,
   adderess=@adderess, 
   emailId=@emailId
   where id=@EId  
End