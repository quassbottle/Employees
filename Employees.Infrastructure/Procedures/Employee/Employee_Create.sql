insert into employees(name, surname, phone, company_id, department_id) 
    values (@Name, @Surname, @Phone, @CompanyId, @DepartmentId)
    returning id;