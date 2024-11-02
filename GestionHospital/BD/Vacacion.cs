using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Vacacion
    {
        public long IdVacacion { get; set; }
        public long? IdEstado { get; set; }
        public long? IdEmpleado { get; set; }
        public DateTime VacFechasolicitud { get; set; }
        public DateTime VacFechainicio { get; set; }
        public DateTime VacFechafin { get; set; }
        public DateTime? VacFechaprobacion { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
