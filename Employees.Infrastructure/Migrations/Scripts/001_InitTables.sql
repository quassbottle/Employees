CREATE TABLE IF NOT EXISTS departments (
    id serial primary key,
    name text,
    phone varchar(16)
);

CREATE TABLE IF NOT EXISTS employees (
    id serial primary key,
    name text,
    surname text,
    phone varchar(16),
    company_id int,
    department_id serial references departments(id) on delete cascade on update cascade
);

CREATE TABLE IF NOT EXISTS passports (
    id serial primary key,
    type text,
    number text,
    constraint unique_type_number unique (type, number),
    employee_id serial unique references employees(id) on delete cascade on update cascade
);

CREATE INDEX ON employees(company_id);
CREATE INDEX ON employees(department_id);