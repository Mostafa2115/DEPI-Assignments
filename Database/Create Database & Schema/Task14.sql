create trigger trg_ValidateEmployeeSalary
on Employees
after update
as
begin
    if exists (select 1 from inserted where Salary < 3000)
    begin
        rollback transaction;
    end
end;
