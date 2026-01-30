create view vw_EmployeesWithDepartments
as
select e.Name,d.DepartmentName,e.Salary
from Employees e join Departments d on d.DepartmentId = e.DepartmentId;
