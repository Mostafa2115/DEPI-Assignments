create proc sp_AddEmployee
    @Name nvarchar(100),
    @Email nvarchar(150),
    @Salary decimal(10,2) = null,
    @DepartmentId int
as
begin
    IF exists (select 1 from Employees where Email = @Email)
        return;
    insert into Employees (Name, Email, Salary, DepartmentId, CreatedAt)
    values (@Name,@Email,isnull(@Salary, 0),@DepartmentId,getdate());
end;
