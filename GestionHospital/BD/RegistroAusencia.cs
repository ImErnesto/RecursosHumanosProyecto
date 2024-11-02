using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class RegistroAusencia
    {
        public RegistroAusencia()
        {
            RegistroDeduccion = new HashSet<RegistroDeduccion>();
        }

        public long IdRegistroausencias { get; set; }
        public long? IdEmpleado { get; set; }
        public long? IdTipoausencia { get; set; }
        public long? IdEstado { get; set; }
        public DateTime RegFechasolicitud { get; set; }
        public DateTime RegFechainicio { get; set; }
        public DateTime? RegFechafin { get; set; }
        public string RegJustificacion { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual TipoAusencia IdTipoausenciaNavigation { get; set; }
        public virtual ICollection<RegistroDeduccion> RegistroDeduccion { get; set; }
    }
}
