create proc sp_UpdateEmployeeSalary
    @EmployeeId int,
    @NewSalary decimal(10,2)
as
begin
    if exists (select 1 from Employees where EmployeeId = @EmployeeId)
    begin
        update Employees
        set Salary = @NewSalary
        where EmployeeId = @EmployeeId;
    end
end;
