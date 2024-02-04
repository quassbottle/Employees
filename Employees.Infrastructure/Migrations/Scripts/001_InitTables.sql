CREATE TABLE IF NOT EXISTS passports (
    id serial PRIMARY KEY,
    type text,
    phone text
);

CREATE TABLE IF NOT EXISTS departments (
    id serial PRIMARY KEY,
    name text,
    phone varchar(16)
);

CREATE TABLE IF NOT EXISTS employees (
    id serial PRIMARY KEY,
    name text,
    surname text,
    phone varchar(16),
    company_id int,
    passport_id serial REFERENCES passports(id),
    department_id serial REFERENCES departments(id)
);