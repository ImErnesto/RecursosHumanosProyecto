using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class RegistroDeduccion
    {
        public long IdRegdeduccion { get; set; }
        public long? IdEmpleado { get; set; }
        public DateTime RegFechadeduccion { get; set; }
        public long? IdRegistroausencias { get; set; }
        public decimal? RegMonto { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual RegistroAusencia IdRegistroausenciasNavigation { get; set; }
    }
}
