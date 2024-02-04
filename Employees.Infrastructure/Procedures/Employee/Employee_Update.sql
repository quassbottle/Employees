update employees set
                     name = coalesce(@Name, name),
                     surname = coalesce(@Surname, surname),
                     phone = coalesce(@Phone, phone),
                     company_id = coalesce(@CompanyId, company_id),
                     passport_id = coalesce(@PassportId, passport_id),
                     department_id = coalesce(@DepartmentId, department_id)
where id = @Id;