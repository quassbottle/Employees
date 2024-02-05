CREATE TABLE IF NOT EXISTS passports (
    id serial primary key,
    type text,
    number text unique 
);

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
    passport_id serial references passports(id),
    department_id serial references departments(id)
);