﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Employees.Infrastructure.Procedures {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlProcedures {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlProcedures() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Employees.Infrastructure.Procedures.SqlProcedures", typeof(SqlProcedures).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into departments(name, phone) values (@Name, @Phone) returning id;.
        /// </summary>
        internal static string Department_Create {
            get {
                return ResourceManager.GetString("Department_Create", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from departments where id = @Id;.
        /// </summary>
        internal static string Department_Delete {
            get {
                return ResourceManager.GetString("Department_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(1) from departments where id = @Id;.
        /// </summary>
        internal static string Department_Exists {
            get {
                return ResourceManager.GetString("Department_Exists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from departments;.
        /// </summary>
        internal static string Department_GetAll {
            get {
                return ResourceManager.GetString("Department_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from departments where id = @Id;.
        /// </summary>
        internal static string Department_GetById {
            get {
                return ResourceManager.GetString("Department_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update departments set
        ///                     name = coalesce(@Name, name),
        ///                     phone = coalesce(@Phone, phone)
        ///where id = @Id;.
        /// </summary>
        internal static string Department_Update {
            get {
                return ResourceManager.GetString("Department_Update", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into employees(name, surname, phone, company_id, passport_id, department_id) 
        ///    values (@Name, @Surname, @Phone, @CompanyId, @PassportId, @DepartmentId)
        ///    returning id;.
        /// </summary>
        internal static string Employee_Create {
            get {
                return ResourceManager.GetString("Employee_Create", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from employees where id = @Id;.
        /// </summary>
        internal static string Employee_Delete {
            get {
                return ResourceManager.GetString("Employee_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(1) from employees where id = @Id;.
        /// </summary>
        internal static string Employee_Exists {
            get {
                return ResourceManager.GetString("Employee_Exists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from employees;.
        /// </summary>
        internal static string Employee_GetAll {
            get {
                return ResourceManager.GetString("Employee_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select e.id, e.name, e.surname, e.phone, e.company_id as CompanyId, e.department_id as DepartmentId, e.passport_id as PassportId 
        ///from employees e
        ///where company_id = @CompanyId;.
        /// </summary>
        internal static string Employee_GetAllByCompanyId {
            get {
                return ResourceManager.GetString("Employee_GetAllByCompanyId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select e.id, e.name, e.surname, e.phone, e.company_id as CompanyId, e.department_id as DepartmentId, e.passport_id as PassportId
        ///from employees e
        ///where department_id = @DepartmentId;.
        /// </summary>
        internal static string Employee_GetAllByDepartmentId {
            get {
                return ResourceManager.GetString("Employee_GetAllByDepartmentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select e.id, e.name, e.surname, e.phone, e.company_id as CompanyId, e.department_id as DepartmentId, e.passport_id as PassportId
        ///from employees e
        ///where id = @Id;
        ///.
        /// </summary>
        internal static string Employee_GetById {
            get {
                return ResourceManager.GetString("Employee_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update employees set
        ///                     name = coalesce(@Name, name),
        ///                     surname = coalesce(@Surname, surname),
        ///                     phone = coalesce(@Phone, phone),
        ///                     company_id = coalesce(@CompanyId, company_id),
        ///                     passport_id = coalesce(@PassportId, passport_id),
        ///                     department_id = coalesce(@DepartmentId, department_id)
        ///where id = @Id;.
        /// </summary>
        internal static string Employee_Update {
            get {
                return ResourceManager.GetString("Employee_Update", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into passports(type, number) values (@Type, @Number) returning id;.
        /// </summary>
        internal static string Passport_Create {
            get {
                return ResourceManager.GetString("Passport_Create", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from passports where id = @Id;.
        /// </summary>
        internal static string Passport_Delete {
            get {
                return ResourceManager.GetString("Passport_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(1) from passports where id = @Id;.
        /// </summary>
        internal static string Passport_Exists {
            get {
                return ResourceManager.GetString("Passport_Exists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(1) from passports where number = @Number;.
        /// </summary>
        internal static string Passport_ExistsByNumber {
            get {
                return ResourceManager.GetString("Passport_ExistsByNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from passports;.
        /// </summary>
        internal static string Passport_GetAll {
            get {
                return ResourceManager.GetString("Passport_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from passports where id = @Id;.
        /// </summary>
        internal static string Passport_GetById {
            get {
                return ResourceManager.GetString("Passport_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to update passports set
        ///                     type = coalesce(@Type, type),
        ///                     number = coalesce(@Number, number)
        ///where id = @Id;.
        /// </summary>
        internal static string Passport_Update {
            get {
                return ResourceManager.GetString("Passport_Update", resourceCulture);
            }
        }
    }
}
