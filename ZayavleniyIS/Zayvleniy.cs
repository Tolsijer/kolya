//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZayavleniyIS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zayvleniy
    {
        public int Номер_заявления { get; set; }
        public string Наименование { get; set; }
        public int id_свойств { get; set; }
    
        public virtual svoistva_zayvleni svoistva_zayvleni { get; set; }
        public DateTime Date { get; internal set; }
        public string Price { get; internal set; }
    }
}
