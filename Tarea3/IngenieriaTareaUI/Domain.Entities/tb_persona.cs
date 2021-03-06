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
    
    public partial class tb_persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_persona()
        {
            this.tb_alias = new HashSet<tb_alias>();
            this.tb_imagen = new HashSet<tb_imagen>();
            this.tb_valor_opcion_detalle_persona = new HashSet<tb_valor_opcion_detalle_persona>();
            this.tb_poblacion_vulnerable = new HashSet<tb_poblacion_vulnerable>();
        }
    
        public int id { get; set; }
        public int id_tipo_identificacion { get; set; }
        public string numero_identificacion { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public int id_estado_civil { get; set; }
        public string sexo { get; set; }
        public string nacionalidad { get; set; }
        public int detenido { get; set; }
        public int desaparecido { get; set; }
        public int revisado_reten { get; set; }
        public string oficio_profesion { get; set; }
        public string expediente_criminal { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
        public Nullable<int> id_subgrupo_victima { get; set; }
        public int numero_autopsia { get; set; }
        public Nullable<int> id_tipo_muerte { get; set; }
        public Nullable<int> id_funcion { get; set; }
        public string nombre_entidad { get; set; }
        public int id_intensidad { get; set; }
        public string atributo { get; set; }
        public string observaciones { get; set; }
        public int id_rol { get; set; }
        public Nullable<int> id_oficial_policia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_alias> tb_alias { get; set; }
        public virtual tb_estado_civil tb_estado_civil { get; set; }
        public virtual tb_funcion tb_funcion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_imagen> tb_imagen { get; set; }
        public virtual tb_intensidad tb_intensidad { get; set; }
        public virtual tb_oficial_policia tb_oficial_policia { get; set; }
        public virtual tb_rol tb_rol { get; set; }
        public virtual tb_subgrupo_victima tb_subgrupo_victima { get; set; }
        public virtual tb_tipo_identificacion tb_tipo_identificacion { get; set; }
        public virtual tb_tipo_muerte tb_tipo_muerte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_valor_opcion_detalle_persona> tb_valor_opcion_detalle_persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_poblacion_vulnerable> tb_poblacion_vulnerable { get; set; }
    }
}
