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
    using System.Collections.Generic;
    
    public partial class lcontroles
    {
        public int id { get; set; }
        public string control { get; set; }
        public Nullable<int> formulario_id { get; set; }
    
        public virtual formulario formulario { get; set; }
    }
}
