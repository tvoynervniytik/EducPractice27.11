//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace up2711.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int Id { get; set; }
        public Nullable<int> Id_Discipline { get; set; }
        public Nullable<int> Id_Specialization { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}