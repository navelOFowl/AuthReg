//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthReg
{
    using System;
    using System.Collections.Generic;
    
    public partial class ФотоПользователя
    {
        public int IDUser { get; set; }
        public byte[] Фото { get; set; }
        public string Путь { get; set; }
    
        public virtual Пользователи Пользователи { get; set; }
    }
}
