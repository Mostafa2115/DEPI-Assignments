SELECT Name,Salary,dbo.fn_CalculateTax(Salary) AS Tax
FROM Employees;
