select e.id, e.name, e.surname, e.phone, e.company_id as CompanyId, e.department_id as DepartmentId
from employees e
where id = @Id;
