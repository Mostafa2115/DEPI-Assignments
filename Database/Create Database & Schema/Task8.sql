create proc sp_GetEmployeeOrderTotal
    @EmployeeId int,
    @TotalAmount decimal(10,2) output
as
begin
    select @TotalAmount = isnull(sum(TotalAmount), 0)
    from Orders
    where EmployeeId = @EmployeeId;
end;
