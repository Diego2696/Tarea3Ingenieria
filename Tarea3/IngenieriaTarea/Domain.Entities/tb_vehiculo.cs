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
    
    public partial class tb_vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_vehiculo()
        {
            this.tb_imagen = new HashSet<tb_imagen>();
        }
    
        public int id { get; set; }
        public int id_tipo_identificacion { get; set; }
        public string numero_identificacion { get; set; }
        public int id_clase { get; set; }
        public string codigo { get; set; }
        public string numero_bien { get; set; }
        public string anno { get; set; }
        public int poliza { get; set; }
        public int decomisado { get; set; }
        public int id_marca { get; set; }
        public int id_color { get; set; }
        public string estilo { get; set; }
        public int id_aseguradora { get; set; }
        public string nombre_entidad { get; set; }
        public int id_intensidad { get; set; }
        public string atributo { get; set; }
        public string observaciones { get; set; }
        public int id_rol { get; set; }
    
        public virtual tb_aseguradora tb_aseguradora { get; set; }
        public virtual tb_clase tb_clase { get; set; }
        public virtual tb_color tb_color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_imagen> tb_imagen { get; set; }
        public virtual tb_intensidad tb_intensidad { get; set; }
        public virtual tb_marca tb_marca { get; set; }
        public virtual tb_rol tb_rol { get; set; }
        public virtual tb_tipo_identificacion tb_tipo_identificacion { get; set; }
    }
}
