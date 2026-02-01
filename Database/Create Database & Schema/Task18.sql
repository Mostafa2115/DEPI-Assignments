create function fn_Last6MonthsDate()
returns DATE
as
begin
    return dateadd(month, -6, getdate());
end;

create view vw_EmployeeOrders_Last6Months
as
select o.EmployeeId,sum(o.TotalAmount) as TotalOrdersAmount
from Orders o
where o.OrderDate >= dbo.fn_Last6MonthsDate()
group by o.EmployeeId;

create nonclustered index IX_Orders_EmployeeId_OrderDate_Total
on Orders (EmployeeId, OrderDate)
include (TotalAmount);

create proc sp_GetTop3Employees_Last6Months
as
begin
    select top 3 
    e.EmployeeId,e.EmployeeName,v.TotalOrdersAmount
    from vw_EmployeeOrders_Last6Months v inner join Employees e on e.EmployeeId = v.EmployeeId
    order by v.TotalOrdersAmount desc;
end;
