update passports set
                     type = coalesce(@Type, type),
                     number = coalesce(@Number, number)
where id = @Id;