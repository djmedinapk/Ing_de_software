//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistence
{
    using System;
    
    public partial class f_traer_datos_sesion_Result
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
        public Nullable<System.DateTime> fecha_ult_session { get; set; }
        public string correo { get; set; }
        public Nullable<int> estado_session { get; set; }
        public string session { get; set; }
        public Nullable<int> id_permisos { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<int> intentos_acceso { get; set; }
        public Nullable<int> n_sesiones { get; set; }
    }
}