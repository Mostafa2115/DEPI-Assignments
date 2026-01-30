create function fn_GetEmployeesByDepartment
(@DepartmentId int)
returns table
as
return
(
    select EmployeeId,Name,Email,Salary,DepartmentId,CreatedAt
    from Employees
    where DepartmentId = @DepartmentId
);


