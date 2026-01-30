create view vw_DepartmentSalarySummary
as
select d.DepartmentName , count(e.EmployeeId) as Total_Employees , avg(e.Salary) as Average_Salary
from Departments d join Employees e on e.DepartmentId=d.DepartmentId
group by d.DepartmentName;
