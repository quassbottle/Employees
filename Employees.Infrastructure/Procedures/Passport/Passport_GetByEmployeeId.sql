select p.id, p.number, p.type, p.employee_id from passports p where employee_id = @EmployeeId;