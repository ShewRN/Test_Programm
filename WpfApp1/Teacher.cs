//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public Nullable<int> id_cabinet { get; set; }
        public Nullable<int> id_class { get; set; }
        public Nullable<int> id_subject { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string time { get; set; }
    
        public virtual Cabinet Cabinet { get; set; }
        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
