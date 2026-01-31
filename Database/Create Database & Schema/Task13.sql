 create table EmployeeAudit (
    EmployeeId int,
    OldSalary decimal(10,2),
    NewSalary decimal(10,2),
    ChangedAt datetime
);

create trigger trg_AuditEmployeeSalary
on Employees
after UPDATE
as
begin
    insert into EmployeeAudit (EmployeeId, OldSalary, NewSalary, ChangedAt)
    select
        d.EmployeeId,
        d.Salary as OldSalary,
        i.Salary as NewSalary,
        getdate()
    from deleted d join inserted i on d.EmployeeId = i.EmployeeId
    where d.Salary <> i.Salary;
end;
