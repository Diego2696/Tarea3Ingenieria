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
    
    public partial class tb_hecho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_hecho()
        {
            this.tb_informacion_basica = new HashSet<tb_informacion_basica>();
        }
    
        public int id { get; set; }
        public string pais { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string barrio { get; set; }
        public System.DateTime fecha { get; set; }
        public string hora { get; set; }
        public byte[] icono { get; set; }
        public string avenida { get; set; }
        public string calle { get; set; }
        public string senas { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public Nullable<int> id_tipo_ubicacion { get; set; }
        public Nullable<int> id_proyeccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_informacion_basica> tb_informacion_basica { get; set; }
        public virtual tb_proyeccion tb_proyeccion { get; set; }
        public virtual tb_tipo_ubicacion tb_tipo_ubicacion { get; set; }
    }
}
