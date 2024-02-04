update departments set
                     name = coalesce(@Name, name),
                     phone = coalesce(@Phone, phone)
where id = @Id;