//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinderCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int User_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public string Username { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Subscibe_Type { get; set; }
        public Nullable<int> ID_User_Info { get; set; }
    }
}
