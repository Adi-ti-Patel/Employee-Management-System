Create procedure InsertDepartment         
(                  
    @Name nvarchar(20),      
    @IsActive nvarchar(20)     
)        
as         
Begin         
    Insert into Department (Name,IsActive)         
    Values (@Name,@IsActive)         
End