//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_alias
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int id_persona { get; set; }
    
        public virtual tb_persona tb_persona { get; set; }
    }
}
