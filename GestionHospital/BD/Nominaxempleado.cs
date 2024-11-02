using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Nominaxempleado
    {
        public long IdNomina { get; set; }
        public long IdEmpleado { get; set; }
        public decimal? NomBonificaciones { get; set; }
        public decimal? NomDeducciones { get; set; }
        public decimal? NomDeduccionSalarial { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Nomina IdNominaNavigation { get; set; }
    }
}
