create function fn_CalculateTax
(@Salary decimal(10,2))
returns decimal(10,2)
as
begin
    return isnull(@Salary, 0) * 0.10;
end;
