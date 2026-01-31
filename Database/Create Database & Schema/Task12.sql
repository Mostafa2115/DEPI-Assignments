create trigger trg_AfterInsert_Employees
on Employees
after insert
as
begin
    update Employees
    set CreatedAt = getdate()
    where EmployeeId in (select EmployeeId from inserted);
end;
