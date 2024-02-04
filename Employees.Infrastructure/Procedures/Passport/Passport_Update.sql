update passports set
                     type = coalesce(@Type, type),
                     phone = coalesce(@Phone, phone)
where id = @Id;